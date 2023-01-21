using Backgammon_Backend.Models;

namespace Backgammon_Backend.Services
{
    public interface IRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(Guid id);
        Task<Game> GetGameByIdAsync(Guid id);

    }
}
