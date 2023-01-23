using Backgammon_Backend.Data;
using Backgammon_Backend.Models;
using Backgammon_Backend.Services.Service_Interfaces;
using System.Xml.Linq;

namespace Backgammon_Backend.Services
{
    public class Repository : IRepository
    {
        readonly HrContext _context;
        public Repository(HrContext context)
        {
            _context = context;
        }
        // USER
        private IEnumerable<User> GetUsers() => _context.Users!;
        public Task<IEnumerable<User>> GetUsersAsync() => Task.Run(() => GetUsers());
        private User GetUserById(Guid id) => _context.Users!.First(u => u.UserId == id);
        public Task<User> GetUserByIdAsync(Guid id) => Task.Run(() => GetUserById(id));
        // GAME
        private Game GetGameById(Guid id) => _context.Games!.First(g => g.GameId == id);
        public Task<Game> GetGameByIdAsync(Guid id) => Task.Run(() => GetGameById(id));
        // PLAYER
        private Player GetPlayerById(Guid id) => _context.Players!.First(p => p.PlayerId == id);
        public Task<Player> GetPlayerByIdAsync(Guid id) => Task.Run(() => GetPlayerById(id));

        // USER
        public void InsertUser(User user)
        {
            _context.Users!.Add(user);
            _context.SaveChanges();
        }
        public void UpdateUser(User updatedUser)
        {
            var UserFromDB = _context.Users!.Single(u => u.UserId == updatedUser.UserId);
            UserFromDB = updatedUser;
            _context.SaveChanges();
        }
        public void DeleteUser(Guid id)
        {
            var userToRemove = _context.Users!.Single(u => u.UserId == id);
            _context.Users!.Remove(userToRemove);
            _context.SaveChanges();
        }
        // PLAYER
        public void InsertPlayer(Player player)
        {
            _context.Players!.Add(player);
            _context.SaveChanges();
        }
        public void DeletePlayer(Guid id)
        {
            var playerToRemove = _context.Players!.Single(p => p.PlayerId == id);
            _context.Players!.Remove(playerToRemove);
            _context.SaveChanges();
        }
        // GAME
        public void InsertGame(Game game)
        {
            _context.Games!.Add(game);
            _context.SaveChanges();
        }
        public void DeleteGame(Guid id)
        {
            var gameToRemove = _context.Games!.Single(p => p.GameId == id);
            _context.Games!.Remove(gameToRemove);
            _context.SaveChanges();
        }

    }
}
