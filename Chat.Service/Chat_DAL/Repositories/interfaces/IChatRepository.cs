using Chat_Models.Helpers;
using Chat_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_DAL.Repositories.interfaces
{
    public interface IChatRepository
    {
        Task<ChatConnection> CreateChatConnectionAsync(string chatId, Guid chatterId, DateTime startedAt);
        Task<IEnumerable<ChatConnection>> GetAllChatsByUserIdAsync(Guid chatterId);
        Task<ChatConnection> GetChatByIdAsync(string chatId);       
        void CloseChatAsync(string ChatId, DateTime endedAt);
        void CloseAllConnections();

    }
}
