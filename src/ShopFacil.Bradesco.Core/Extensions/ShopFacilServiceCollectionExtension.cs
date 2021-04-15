using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopFacil.Bradesco.Core.Services;
using ShopFacil.Bradesco.Core.Settings;
using System;

namespace ShopFacil.Bradesco.Core.Extensions
{
    public static class ShopFacilServiceCollectionExtension
    {
        public static IServiceCollection AddShopFacilBradesco(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<ShopFacilSettings>(config.GetSection(ShopFacilSettings.Settings));
            services.AddHttpClient<IBoletoService, BoletoService>();
            return services;
        }

        public static IServiceCollection AddShopFacilBradesco(this IServiceCollection services, Action<ShopFacilSettings> settings)
        {
            services.Configure(settings);
            services.AddHttpClient<IBoletoService, BoletoService>();
            return services;
        }
    }
}
