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
        Connection CreateChatConnection(string chatId, Guid chatterId, DateTime startedAt);
        Task<Connection> CreateChatConnectionAsync(string chatId, Guid chatterId, DateTime startedAt);
        Task<IEnumerable<Connection>> GetAllConnectionsByUserIdAsync(Guid chatterId);
        Task<Connection> GetConnectionByIdAsync(string chatId);       
        void CloseChatConnectionAsync(string ChatId, DateTime endedAt);
        void CloseAllConnections();
        bool CheckReconnectConnection(Guid chatterId);

    }
}
