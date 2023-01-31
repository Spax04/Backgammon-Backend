﻿using Chat_Models.Helpers;
using Chat_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Services.Interfaces
{
    public interface IChatService
    {
        Task<Chatter> GetOrAddChatterAsync(Guid chaterId, string name);
        Task<DateTime> GetLastSeenAsync(Guid chatterId);
        Task<Chatter> GetChatterAsync(Guid chatterId);
        Task<bool> ConnectChatterAsync(Guid chatterOneId, Guid chatterTwoId, Guid chatId);
        Task<bool> DisconnectChatterAsync(Guid chater, Guid chatId);
        Task<IEnumerable<Chatter>> GetChattersAsync(Guid chatId);
        void CloseAllConnectionsAsync();
    }
}
