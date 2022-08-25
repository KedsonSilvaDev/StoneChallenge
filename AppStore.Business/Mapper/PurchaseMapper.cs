using AppStore.Business.Entities;
using AppStore.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AppStore.Business.Mapper
{
    public static class PurchaseMapper
    {
        public static Purchase PurchaseToModel(this PurchaseModel purchaseModel)
        {
            Purchase purchase = new()
            {
                CardNumber = Regex.Replace(purchaseModel.CardNumber, "[^0-9]+", ""),
                CardType = purchaseModel.CardType,
                SecurityCode = purchaseModel.SecurityCode,
                TaxNumber = Regex.Replace(purchaseModel.TaxNumber, "[^0-9]+", ""),
                CodeApp = purchaseModel.CodeApp
            };

            return purchase;

        }
    }
}
