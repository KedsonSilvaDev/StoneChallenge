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
    public static class CardMapper
    {
        public static Card CardToModel(this CardModel cardModel)
        {
            Card card = new()
            {
                CardNumber = FormatCard(cardModel.CardNumber),
                CardType = cardModel.CardType,
                SecurityCode = cardModel.SecurityCode,
                TaxNumber = Regex.Replace(cardModel.TaxNumber, "[^0-9]+", "")
            };

            return card;
        }

        //ingles ou portugues
        public static string FormatCard(string text)
        {
            return text.Replace(".", string.Empty);
        }
    }
}
