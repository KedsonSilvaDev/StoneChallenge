using AppStore.Business.Entities;
using System.Threading.Tasks;

namespace AppStore.Business.Interfaces
{
    public interface IUserServices
    {
        Task<User> CreateUserLogin(User user);

        Task<User> Get(string taxNumber);
    }
}
