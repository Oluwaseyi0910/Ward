using RoyalKiddiesWard.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalKiddiesWard.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserIfExists(string email);
        Task<User> CheckPassword(User user, string password);
        Task<User> AuthenticateUser(string email, string password);
        Task<User> GetUserIfAccountIsRestricted(string email);
        Task<User> GetNewUserIfExists(string email, string password);
        Task<List<string>> GetRolesByUser(User user);
        

    }
}
