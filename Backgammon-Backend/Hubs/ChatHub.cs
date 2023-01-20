using Backgammon_Backend.Hubs.Clients;
using Backgammon_Backend.Models;
using Microsoft.AspNetCore.SignalR;

namespace Backgammon_Backend.Hubs
{
    public class ChatHub : Hub<IChatClient>
    {
        public async Task SendMessage(ChatMessage message)
        {
            await Clients.All.ReceiveMessage( message);
        }
    }
}
