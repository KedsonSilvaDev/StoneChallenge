using AppStore.Business.Entities;
using AppStore.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Business.Interfaces
{
    public interface ICardRepository
    {
        Task<Card> CreateCard(Card card);
        Task<Card> GetCardByCardNumberAndType(string cardNumber, CardType cardType, string taxNumber);
    }
}
