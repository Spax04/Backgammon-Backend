using Backgammon_Backend.Models;

namespace Backgammon_Backend.Services
{
    public interface IRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        Task<Game> GetGameByIdAsync(Guid id);
        Task<Player> GetPlayerByIdAsync(Guid id);
        
        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(Guid id);
        void InsertGame(Game game);
        void DeleteGame(Guid id);
        void InsertPlayer(Player player);
        void DeletePlayer(Guid id);
    }
}
