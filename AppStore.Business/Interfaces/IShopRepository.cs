using AppStore.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Business.Interfaces
{
    public interface IShopRepository
    {
        Task<List<Shop>> GetShop();
        Task<Shop> ValidateShopItem(string codeApp);
    }
}
