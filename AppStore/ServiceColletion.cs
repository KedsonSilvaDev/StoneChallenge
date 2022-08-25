using AppStore.Business.Interfaces;
using AppStore.Repository;
using AppStore.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace AppStore
{
    public static class ServiceColletion
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IShopServices, ShopServices>();
            services.AddScoped<ICardServices, CardServices>();
            services.AddScoped<IPurchaseServices, PurchaseServices>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IShopRepository, ShopRepository>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();

            return services;
        }

        public static IServiceCollection AddSettingsConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppStoreRepositorySettings>(configuration.GetSection(nameof(AppStoreRepositorySettings)));
            services.AddSingleton<IAppStoreRepositorySettings>(r => r.GetRequiredService<IOptions<AppStoreRepositorySettings>>().Value);

            return services;
        }
    }
}
