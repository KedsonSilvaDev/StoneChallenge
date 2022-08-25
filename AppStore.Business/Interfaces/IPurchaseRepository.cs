using AppStore.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Business.Interfaces
{
    public interface IPurchaseRepository
    {
        Task<Purchase> CreatePurchaseUser(Purchase purchase);
        void SettlementPurchase(string purchaseId);
        Task<Purchase> GetPurchaseById(string purchaseId);

    }
}
