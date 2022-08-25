using AppStore.Business.Entities;
using AppStore.Business.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> userMongoCollection;

        public UserRepository(IAppStoreRepositorySettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            userMongoCollection = database.GetCollection<User>(nameof(User));
        }
        public async Task<User> CreateUserLogin(User user)
        {

            await userMongoCollection.InsertOneAsync(user); 

            return user;
        }

        public async Task<User> ValidateUserExists(string taxNumber)
        {
                User User = await userMongoCollection.Find(u => u.TaxNumber == taxNumber).FirstOrDefaultAsync();

                return User;            
        }
    }
}
