using Backgammon_Backend.Dto;
using Identity_Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace Backgammon_Backend.Services.Service_Interfaces
{
    public interface IAuthRepository
    {
        Task<User> RegisterUserAsync(UserDto request);
        Task<string> LoginUserAsync(UserDto request);
    }
}
