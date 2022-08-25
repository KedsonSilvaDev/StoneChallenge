using AppStore.Business.Entities;
using AppStore.Business.Enums;
using AppStore.Business.Interfaces;
using AppStore.Business.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Service
{
    public class PurchaseServices : IPurchaseServices
    {
        private readonly IPurchaseRepository purchaseRepository;
        private readonly IUserRepository userRepository;
        private readonly IShopRepository shopRepository;

        public PurchaseServices(IPurchaseRepository purchaseRepository, IUserRepository userRepository, IShopRepository shopRepository)
        {
            this.purchaseRepository = purchaseRepository;
            this.userRepository = userRepository;
            this.shopRepository = shopRepository;
        }

        public async Task<Purchase> CreatePurchaseUser(Purchase purchase)
        {
            CardValidator.ValidateCardType(purchase.CardType.ToString());

            User userExist = await userRepository.ValidateUserExists(purchase.TaxNumber);
            if (userExist != null)
            {
                Shop appExists = await shopRepository.ValidateShopItem(purchase.CodeApp);
                if (appExists != null)
                {
                    purchase.Status = PurchaseStatus.Created;

                    await purchaseRepository.CreatePurchaseUser(purchase);
                    return purchase;
                }
                else
                    throw new Exception("Código de Aplicativo Inválido");
            }
            else
                throw new Exception("Usuário não encontrado. Favor efetuar cadastro antes de realizar uma compra.");
        }

        public async Task<Purchase> GetPurchaseById(string purchaseId)
        {
            Purchase purchase = await purchaseRepository.GetPurchaseById(purchaseId);
            return purchase;
        }

        public void SettlementPurchase(string purchaseId)
        {
            purchaseRepository.SettlementPurchase(purchaseId);
        }
    }
}
