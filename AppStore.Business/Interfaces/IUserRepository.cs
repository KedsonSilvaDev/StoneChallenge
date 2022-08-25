using AppStore.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Business.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUserLogin(User user);
        Task<User> ValidateUserExists(string taxNumber);
    }
}
