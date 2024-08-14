using API.Application_.Abstractions.Services;
using API.Application_.Abstractions.Token;
using API.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.Abstractions.Storage;
using API.Infrastructure.Enums;
using API.Infrastructure.Services.Storage;
using API.Infrastructure.Services.Storage.Local;
using TokenHandler = API.Infrastructure.Services.TokenHandler;
using API.Infrastructure.Services.Storage.Azure;

namespace API.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
            serviceCollection.AddScoped<IMailService, MailService>();

            //serviceCollection.AddScoped<IStorageService, StorageService>();
        }
        //public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
        //{
        //    serviceCollection.AddScoped<IStorage, T>();
        //}
        //public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType) 
        //{
        //    switch (storageType)
        //    {
        //        case StorageType.Local:
        //            serviceCollection.AddScoped<IStorage, LocalStorage>();
        //            break;
        //        case StorageType.Azure:
        //            serviceCollection.AddScoped<IStorage, AzureStorage>();
        //            break;
        //        case StorageType.AWS:

        //            break;
        //        default:
        //            serviceCollection.AddScoped<IStorage, LocalStorage>();
        //            break;
        //    }
        //}
    }
}
