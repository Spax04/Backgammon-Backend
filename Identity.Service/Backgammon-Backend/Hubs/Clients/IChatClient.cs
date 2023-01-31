using Backgammon_Backend.Models;

namespace Backgammon_Backend.Hubs.Clients
{
    public interface IChatClient
    {
        Task ReceiveMessage(ChatMessage message);
    }
}
