using AppStore.Business.Entities;
using AppStore.Business.Enums;
using AppStore.Business.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly IMongoCollection<Card> cardMongoCollection;

        public CardRepository(IAppStoreRepositorySettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            cardMongoCollection = database.GetCollection<Card>(nameof(Card));
        }
        public async Task<Card> CreateCard(Card card)
        {
            await cardMongoCollection.InsertOneAsync(card);

            return card;
        }

        public async Task<Card> ValidateCardExists(string cardNumber)
        {
            Card card = await cardMongoCollection.Find(c => c.CardNumber == cardNumber).FirstOrDefaultAsync();

            return card;
        }

        public async Task<Card> GetCardByCardNumberAndType(string cardNumber, CardType cardType, string taxNumber)
        {
            Card card = await cardMongoCollection.Find(c => (c.CardNumber == cardNumber) && (c.CardType == cardType) && (c.TaxNumber == taxNumber)).FirstOrDefaultAsync();
            
            return card;
        }
    }
}
