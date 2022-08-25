using AppStore.Business.Entities;
using AppStore.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Business.Validator
{
    public class CardValidator
    {
        public static void Validate(Card card)
        {
            if (card.CardNumber.Length != 16)
                throw new Exception("Cartão inválido. Verifique a quantidade de digitos.");
        }

        public static void ValidateCardType(string cardType)
        {
            if (cardType == CardType.Debit.ToString())
                throw new Exception("Forma de pagamento inválida.");
        }


    }
}
