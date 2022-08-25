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
    public class ShopRepository : IShopRepository
    {
        private readonly IMongoCollection<Shop> shopMongoCollection;

        public ShopRepository(IAppStoreRepositorySettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            shopMongoCollection = database.GetCollection<Shop>(nameof(Shop));
        }

        public async Task<List<Shop>> GetShop()
        {
            return await shopMongoCollection.Find(s => true).ToListAsync();
        }

        public async Task<Shop> ValidateShopItem(string codeApp)
        {
            Shop shop = await shopMongoCollection.Find(s => s.CodeApp == codeApp).FirstOrDefaultAsync();

            return shop;
        }
    }
}
