using Chat_DAL.Repositories.interfaces;
using Chat_Models.Helpers;
using Chat_Models.Helpers.ModelResponses;
using Chat_Models.Models;
using Chat_Services.Interfaces;
using System;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace Chat_Services
{
    public class ChatService : IChatService
    {
        readonly IChatterRepository _chatterRepo;
        readonly IChatRepository _chatRepo;

        public ChatService(IChatterRepository chatterRepo, IChatRepository chatRepo)
        {
            _chatterRepo = chatterRepo;
            _chatRepo = chatRepo;
        }

        public void CloseAllConnectionsAsync() => _chatRepo.CloseAllConnections();

        private bool ConnectChatter(Guid chatterId, string chatId)
        {
            _chatRepo.CreateChatConnection(chatId, chatterId,  DateTime.Now);
            var chatter = _chatterRepo.GetChatterAsync(chatterId);
            if (chatter != null)
                return false;
            _chatterRepo.SetConnectedAsync(chatterId);
            return true;
        }
        public async Task<bool> ConnectChatterAsync(Guid chatterId, string chatId) => await Task.Run(() => ConnectChatter(chatterId,  chatId));


        public async Task<bool> DisconnectChatterAsync(Guid chatter, string chatId)
        {
            _chatRepo.CloseChatConnectionAsync(chatId, DateTime.Now);
            var chats = await _chatRepo.GetAllChatsConnectionsByUserIdAsync(chatter);
            if (!chats.Any(c => !c.IsClosed))
            {
                await _chatterRepo.SetDisconnectedAsync(chatter);
                return true;
            }
            return false;
        }

        private Chatter GetChatter(Guid chatterId)
        {
            var chatter = _chatterRepo.GetChatterAsync(chatterId).Result;
            return chatter;
        }
        public async Task<Chatter> GetChatterAsync(Guid chatterId) => await Task.Run(() => GetChatter(chatterId));

        
        public async Task<IEnumerable<Chatter>> GetChattersAsync(Guid selfChatter) 
        {
            return (await _chatterRepo.GetChattersAreOnlineAsync(selfChatter));
        }

        private DateTime GetLastSeen(Guid chatterId)
        {
            var lastSeen = _chatRepo.GetAllChatsConnectionsByUserIdAsync(chatterId).Result.Max(c => c.EndedAt);
            return lastSeen;
        }
        public async Task<DateTime> GetLastSeenAsync(Guid chatterId) => await Task.Run(() => GetLastSeen(chatterId));

        public async Task<Chatter> GetOrAddChatterAsync(Guid chatterId, string name)
        {
            if(!(_chatterRepo.isChatterExistAsync(chatterId)))
            {
                await _chatterRepo.AddChatterAsync(chatterId, name); 
            }

            return  await _chatterRepo.GetChatterAsync(chatterId); 
        }


    }
}