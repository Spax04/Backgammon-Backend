using Backgammon_Backend.Data;
using Backgammon_Backend.Dto;
using Backgammon_Backend.Models;
using Backgammon_Backend.Services.Service_Interfaces;
using Microsoft.AspNetCore.Mvc;
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
        readonly HrContext _context;
        private readonly IConfiguration _config;
        public AuthRepository(HrContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
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



        private string LoginUser(UserDto request)
        {
            User user = _context.Users.FirstOrDefault(user => user.UserName == request.UserName);

            if(user == null)
            {
                return "user doesnt exist";
            }
            

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return "password isn't correct";
            }
            string token = CreateToken(user);
            return token;
        }

        public Task<string> LoginUserAsync(UserDto request) => Task.Run(() => LoginUser(request));


        // Token section
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }


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
