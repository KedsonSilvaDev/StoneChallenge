using AppStore.Business.Entities;
using AppStore.Business.Interfaces;
using AppStore.Business.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Service
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository userRepository;

        public UserServices(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<User> CreateUserLogin(User user)
        {
            UserValidator.Validate(user);

            User userExist = await Get(user.TaxNumber);

            if (userExist == null)
            {
                await userRepository.CreateUserLogin(user);

                return user;
            }
            else
                throw new Exception("Usuário já cadastrado");
        }

        public async Task<User> Get(string taxNumber)
        {
            User user = await userRepository.ValidateUserExists(taxNumber);
            return user;
        }
    }
}
