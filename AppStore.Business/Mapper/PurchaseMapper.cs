using AppStore.Business.Entities;
using AppStore.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Business.Mapper
{
    public static class PurchaseMapper
    {
        public static Purchase PurchaseToModel(this PurchaseModel purchaseModel)
        {
            Purchase purchase = new()
            {
                CardNumber = purchaseModel.CardNumber,
                CardType = purchaseModel.CardType,
                SecurityCode = purchaseModel.SecurityCode,
                TaxNumber = purchaseModel.TaxNumber,
                CodeApp = purchaseModel.CodeApp                
            };

            return purchase;

        }
    }
}
