using AppStore.Business.Entities;
using AppStore.Business.Enums;
using AppStore.Business.Interfaces;
using MongoDB.Driver;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly IMongoCollection<Purchase> purchaseMongoCollection;

        public PurchaseRepository(IAppStoreRepositorySettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            purchaseMongoCollection = database.GetCollection<Purchase>(nameof(Purchase));
        }

        public async Task<Purchase> CreatePurchaseUser(Purchase purchase)
        {
            await purchaseMongoCollection.InsertOneAsync(purchase);

            CreatePurchaseQueue(purchase.Id);

            return purchase;
        }

        public void SettlementPurchase(string purchaseId)
        {
            var filter = Builders<Purchase>.Filter.Eq("Id", purchaseId);
            var update = Builders<Purchase>.Update.Set("Status", PurchaseStatus.Settlement);

            purchaseMongoCollection.UpdateOne(filter, update);
        }

        public void CreatePurchaseQueue(string purchaseId)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "PurchaseQueue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                string message = purchaseId;
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "PurchaseQueue",
                                     basicProperties: null,
                                     body: body);
            }


        }

        public async Task<Purchase> GetPurchaseById(string purchaseId)
        {
            Purchase purchase = await purchaseMongoCollection.Find(p => p.Id == purchaseId).FirstOrDefaultAsync();

            return purchase;
        }
    }
}
