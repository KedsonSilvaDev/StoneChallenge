using AppStore.Business.Entities;
using AppStore.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Business.Interfaces
{
    public interface ICardServices
    {
        Task<Card> CreateCard(Card card);
        Task<Card> Get(string cardNumber, CardType cardType, string taxNumber);
    }
}
