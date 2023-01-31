using Chat_DAL.Data;
using Chat_DAL.Repositories.interfaces;
using Chat_Models.Helpers;
using Chat_Models.Helpers.ModelResponses;
using Chat_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_DAL.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private ChatDataContext _context;
        public ChatRepository(ChatDataContext context)
        {
            _context = context;
        }

        // FINISHED
        private Chat CreateChat(Guid chatId, Guid chatterId, DateTime startedAt)
        {
            Chat newChat = new Chat
            {
                ChatId = chatId,
                ChatterId = chatterId,
                StartedAt = startedAt,
                IsClosed = false
            };
            _context!.Chats!.Add(newChat);
            _context!.SaveChanges();

            return newChat;
        }
        public async Task<Chat> CreateChatAsync(Guid chatId, Guid chatterId, DateTime startedAt) => await Task.Run(() => CreateChat(chatId, chatterId, startedAt));

        // FINISHED

        

        // FINISHED
        private Chat GetChatById(Guid chatId)
        {
            var chat = _context!.Chats!.FirstOrDefault(c => c.ChatId == chatId);
            if(chat == null)
                throw new ArgumentException("Not Found");

            return new Chat
            {
                ChatId = chat.ChatId,
                ChatterId = chat.ChatterId!,
                IsClosed= chat.IsClosed,
                StartedAt = chat.StartedAt,
                EndedAt = chat.EndedAt
            };
        }
        public async Task<Chat> GetChatByIdAsync(Guid chatId) => await Task.Run(() => GetChatById(chatId));

        // FINISHED
        private IEnumerable<Chat> GetAllChatsByUserId(Guid chatterId)
        {

            var allChats = _context!.Chatters!.Find(chatterId)!
                .Chats!
                .Select(u => new Chat
                {
                    ChatId = u.ChatId,
                    ChatterId = (Guid)u.ChatterId!,
                    IsClosed = u.IsClosed,
                    StartedAt = u.StartedAt,
                    EndedAt = u.EndedAt
                });

             yield return (Chat)allChats;               
        }
        public async Task<IEnumerable<Chat>> GetAllChatsByUserIdAsync(Guid chatterId) => await Task.Run(() => GetAllChatsByUserId(chatterId));


        public void CloseChatAsync(Guid chatId, DateTime endedAt)
        {
            var chat = _context?.Chats?.Find(chatId);
            if (chat == null)
                throw new ArgumentException("Not Found");

            chat.IsClosed = true;
            chat.EndedAt = endedAt;
            _context!.SaveChanges();
        }

        public void CloseAllConnections()
        {
            foreach(var chat in _context!.Chats!)
            {
                if (!chat.IsClosed)
                {
                    chat.IsClosed = true;
                    chat.EndedAt = DateTime.Now;
                }
            }
            _context.SaveChanges();
        }  
    }
}
