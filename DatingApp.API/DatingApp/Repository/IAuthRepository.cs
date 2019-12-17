using DatingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Repository
{
   public interface IAuthRepository
    {
        Task<User> Register(User user, string Password);
        Task<User> LogIn(string username, string Password);
        Task<bool> UserExists(string username);
    }
}
