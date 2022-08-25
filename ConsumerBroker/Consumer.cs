using AppStore.Business.Entities;
using AppStore.Business.Interfaces;
using AppStore.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerBroker
{
    class Consumer
    {
        private readonly IPurchaseServices _purchaseService;

        public Consumer(IPurchaseServices purchaseService)
        {
            _purchaseService = purchaseService;
        }

        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Services.GetRequiredService<ProcessRabbit>().ProcessQueue();            
        }

        private static IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true)
       .SetBasePath(Directory.GetCurrentDirectory()).AddEnvironmentVariables().Build();

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddTransient<ProcessRabbit>();
                    services.AddTransient<IPurchaseServices, PurchaseServices>();
                    services.ConfigureRepositoryServices(configuration);
                });
        }


    }
}
