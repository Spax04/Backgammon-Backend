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
        private ChatConnection CreateChatConnection(string chatId, Guid chatterId, DateTime startedAt)
        {
            ChatConnection newChat = new ChatConnection
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
        public async Task<ChatConnection> CreateChatConnectionAsync(string chatId, Guid chatterId, DateTime startedAt) => await Task.Run(() => CreateChatConnection(chatId,  chatterId,   startedAt));

        // FINISHED

        

        // FINISHED
        private ChatConnection GetChatById(string chatId)
        {
            var chat = _context!.Chats!.FirstOrDefault(c => c.ChatId == chatId);
            if(chat == null)
                throw new ArgumentException("Not Found");

            return new ChatConnection
            {
                ChatId = chat.ChatId,
                ChatterId = chat.ChatterId!,
                IsClosed= chat.IsClosed,
                StartedAt = chat.StartedAt,
                EndedAt = chat.EndedAt
            };
        }
        public async Task<ChatConnection> GetChatByIdAsync(string chatId) => await Task.Run(() => GetChatById(chatId));

        // FINISHED
        private IEnumerable<ChatConnection> GetAllChatsByUserId(Guid chatterId)
        {

            var allChats = _context!.Chatters!.Find(chatterId)!
                .Chats!
                .Select(u => new ChatConnection
                {
                    ChatId = u.ChatId,
                    ChatterId = u.ChatterId!,
                    IsClosed = u.IsClosed,
                    StartedAt = u.StartedAt,
                    EndedAt = u.EndedAt
                });

             yield return (ChatConnection)allChats;               
        }
        public async Task<IEnumerable<ChatConnection>> GetAllChatsByUserIdAsync(Guid chatterId) => await Task.Run(() => GetAllChatsByUserId(chatterId));


        public void CloseChatAsync(string chatId, DateTime endedAt)
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
