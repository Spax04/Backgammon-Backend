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

        private bool ConnectChatter(Guid chatterId, Guid chatId)
        {
            _chatRepo.CreateChatAsync(chatId, chatterId, DateTime.Now);
            var chatter = _chatterRepo.GetChatterAsync(chatId);
            if (chatter != null)
                return false;
            _chatterRepo.SetConnectedAsync(chatterId);
            return true;
        }
        public async Task<bool> ConnectChatterAsync(Guid chatterId, Guid chatId) => await Task.Run(() => ConnectChatter(chatterId, chatId));


        public async Task<bool> DisconnectChatterAsync(Guid chatter, Guid chatId)
        {
            _chatRepo.CloseChatAsync(chatId, DateTime.Now);
            var chats = await _chatRepo.GetAllChatsByUserIdAsync(chatId);
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

        
        public async Task<IEnumerable<Chatter>> GetChattersAsync(Guid chatId)
        {
            return (await _chatterRepo.GetChattersAsync())
                            .Where(c => c.Id != chatId)
                            .ToList();
        }

        private DateTime GetLastSeen(Guid chatterId)
        {
            var lastSeen = _chatRepo.GetAllChatsByUserIdAsync(chatterId).Result.Max(c => c.EndedAt);
            return lastSeen;
        }
        public async Task<DateTime> GetLastSeenAsync(Guid chatterId) => await Task.Run(() => GetLastSeen(chatterId));

        public async Task<Chatter> GetOrAddChatterAsync(Guid chatterId, string name)
        {
            var chatter = await _chatterRepo.GetChatterAsync(chatterId);
            if (chatter != null)
                return chatter;

            chatter = await _chatterRepo.AddChatterAsync(chatterId, name);
            return chatter;
        }

    }
}