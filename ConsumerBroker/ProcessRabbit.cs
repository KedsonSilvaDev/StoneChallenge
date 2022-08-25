using AppStore.Business.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerBroker
{
    public class ProcessRabbit
    {
        private readonly IPurchaseServices _purchaseService;
        public ProcessRabbit(IPurchaseServices purchaseService)
        {
            _purchaseService = purchaseService;
        }

        public void ProcessQueue()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "PurchaseQueue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    byte[] body = ea.Body.ToArray();
                    string message = Encoding.UTF8.GetString(body);

                    Process(message);
                };
                channel.BasicConsume(queue: "PurchaseQueue",
                                     autoAck: true,
                                     consumer: consumer);

                Console.WriteLine("Fila de Processamento iniciada. Consulte sua compra, por gentileza.");
                Console.ReadLine();
            }
        }

        private void Process(string message)
        {
            _purchaseService.SettlementPurchase(message);

        }
    }
}
