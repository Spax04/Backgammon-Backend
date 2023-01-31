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
        Task<Chat> CreateChatAsync(Guid chatId, Guid chatterId, DateTime startedAt);
        Task<IEnumerable<Chat>> GetAllChatsByUserIdAsync(Guid chatterId);
        Task<Chat> GetChatByIdAsync(Guid chatId);       
        void CloseChatAsync(Guid ChatId, DateTime endedAt);
        void CloseAllConnections();

    }
}
