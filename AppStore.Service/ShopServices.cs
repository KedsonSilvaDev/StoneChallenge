using AppStore.Business.Entities;
using AppStore.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Service
{
    public class ShopServices : IShopServices
    {
        private readonly IShopRepository shopRepository;

        public ShopServices(IShopRepository shopRepository)
        {
            this.shopRepository = shopRepository;
        }
        public async Task<List<Shop>> GetShop()
        {
           List<Shop> shopList = await shopRepository.GetShop();
            return shopList;
        }

        public async Task<Shop> Get(string codeApp)
        {
            Shop shop = await shopRepository.ValidateShopItem(codeApp);

            return shop;
        }
    }
}
