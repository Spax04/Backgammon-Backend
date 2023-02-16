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
        public Connection CreateChatConnection(string chatId, Guid chatterId, DateTime startedAt)
        {
            Connection newChat = new Connection
            {
                ConnectionId = chatId,
                ChatterId = chatterId,
                StartedAt = startedAt,
                IsClosed = false
            };
            _context!.Chats!.Add(newChat);
            _context!.SaveChanges();

            return newChat;
        }
        public async Task<Connection> CreateChatConnectionAsync(string chatId, Guid chatterId, DateTime startedAt) => await Task.Run(() => CreateChatConnection(chatId,  chatterId,   startedAt));

        // FINISHED

        

        // FINISHED
        private Connection GetChatById(string chatId)
        {
            var chat = _context!.Chats!.FirstOrDefault(c => c.ConnectionId == chatId);
            if(chat == null)
                throw new ArgumentException("Not Found");

            return new Connection
            {
                ConnectionId = chat.ConnectionId,
                ChatterId = chat.ChatterId!,
                IsClosed= chat.IsClosed,
                StartedAt = chat.StartedAt,
                EndedAt = chat.EndedAt
            };
        }
        public async Task<Connection> GetChatByIdAsync(string chatId) => await Task.Run(() => GetChatById(chatId));

        // FINISHED
        private IEnumerable<Connection> GetAllChatsByUserId(Guid chatterId)
        {

            var allChats = _context!.Chatters!.Find(chatterId)!
                .Chats!
                .Select(u => new Connection
                {
                    ConnectionId = u.ConnectionId,
                    ChatterId = u.ChatterId!,
                    IsClosed = u.IsClosed,
                    StartedAt = u.StartedAt,
                    EndedAt = u.EndedAt
                });

             yield return (Connection)allChats;               
        }
        public async Task<IEnumerable<Connection>> GetAllConnectionsByUserIdAsync(Guid chatterId) => await Task.Run(() => GetAllChatsByUserId(chatterId));


        public void CloseChatConnectionAsync(string chatId, DateTime endedAt)
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
