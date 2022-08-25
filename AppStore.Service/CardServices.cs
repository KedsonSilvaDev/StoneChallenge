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
    public class CardServices : ICardServices
    {
        private readonly ICardRepository cardRepository;
        private readonly IUserRepository userRepository;

        public CardServices(ICardRepository cardRepository, IUserRepository userRepository)
        {
            this.cardRepository = cardRepository;
            this.userRepository = userRepository;
        }
        public async Task<Card> CreateCard(Card card)
        {
            CardValidator.Validate(card);

            User userExists = await userRepository.ValidateUserExists(card.TaxNumber);

            if (userExists != null)
            {
                Card cardExists = await Get(card.CardNumber, card.CardType, card.TaxNumber);

                if (cardExists == null)
                {
                    await cardRepository.CreateCard(card);
                    return card;
                }
                else
                    throw new Exception("Cartão já cadastrado para este usuário");
            }
            else
                throw new Exception("Usuário não cadastrado. Cadastre primeiro o usuário para adicionar um cartão.");
        }

        public async Task<Card> Get(string cardNumber, CardType cardType, string taxNumber)
        {
            Card card = await cardRepository.GetCardByCardNumberAndType(cardNumber, cardType, taxNumber);
            return card;
        }

    }
}
