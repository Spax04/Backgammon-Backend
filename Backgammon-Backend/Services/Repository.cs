using Backgammon_Backend.Data;
using Backgammon_Backend.Models;
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

        private IEnumerable<User> GetUsers() => _context.Users!;
        public Task<IEnumerable<User>> GetUsersAsync() => Task.Run(() => GetUsers());

        private User GetUserById(Guid id) => _context.Users!.First(user => user.UserId == id);
        public Task<User> GetUserByIdAsync(Guid id) => Task.Run(() => GetUserById(id));


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
    }
}
