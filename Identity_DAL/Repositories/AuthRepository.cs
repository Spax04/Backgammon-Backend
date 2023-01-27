using Backgammon_Backend.Data;
using Backgammon_Backend.Dto;
using Backgammon_Backend.Services.Service_Interfaces;
using Identity_DAL.Authorization.Interfaces;
using Identity_Models.Authentication;
using Identity_Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Backgammon_Backend.Services
{
    public class AuthRepository : IAuthRepository
    {
        private DevDataContext _context;
        private readonly IConfiguration _config;
        private IJwtUtilits _jwtUtilits;
        public AuthRepository(DevDataContext context, IConfiguration config, IJwtUtilits jwtUtilits)
        {
            _context = context;
            _config = config;
            _jwtUtilits = jwtUtilits;
        }


        private User RegisterUser(UserDto request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User user = new User();
            
            user.UserName = request.UserName;
            user.Email = request.Email;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public Task<User> RegisterUserAsync(UserDto request) => Task.Run(() => RegisterUser(request));



        private string LoginUser(AuthenticationRequest request)
        {
            User user = _context.Users.First(user => user.UserName == request.Username);

            if(user == null)
            {
                return "user doesnt exist";
            }
            

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return "password isn't correct";
            }
            string token = _jwtUtilits.CreateToken(user);
            return token;
        }

        public Task<string> LoginUserAsync(UserDto request) => Task.Run(() => LoginUser(request));


        // Token section
       


        // Hashing section
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512()) // Enctypted algorithem
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
