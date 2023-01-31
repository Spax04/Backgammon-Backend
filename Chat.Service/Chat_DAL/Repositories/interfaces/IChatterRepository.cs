﻿using Chat_Models.Helpers;
using Chat_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_DAL.Repositories.interfaces
{
    public interface IChatterRepository
    {
        Task<Chatter> AddChatterAsync(Guid chatterId, string name);
        Task<Chatter> GetChatterAsync(Guid chatterId);
        Task<IEnumerable<Chatter>> GetChattersAsync();
        Task SetConnectedAsync(Guid cahatterId);
        Task SetDisconnectedAsync(Guid cahatterId);
    }
}
