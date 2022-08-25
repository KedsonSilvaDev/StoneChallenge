using AppStore.Business.Interfaces;
using AppStore.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerBroker
{
    public static class ConsumerConfiguration
    {
        public static IServiceCollection ConfigureRepositoryServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppStoreRepositorySettings>(configuration.GetSection(nameof(AppStoreRepositorySettings)));
            services.AddSingleton<IAppStoreRepositorySettings>(a => a.GetRequiredService<IOptions<AppStoreRepositorySettings>>().Value);
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();

            return services;
        }
    }
}
