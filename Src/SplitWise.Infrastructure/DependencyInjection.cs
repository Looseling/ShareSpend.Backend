using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using ShareSpend.Application.IRepository;
using ShareSpend.Infrastructure.Data.Repository;
using ShareSpend.Infrastructure.llm;
using ShareSpend.Infrastructure.ReceiptsStorage;

namespace SplitWise.AddInfrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection container)
    {
        container.AddScoped<IReceiptImageProcessor, ReceiptImageProcessor>();

        //Repository
        container.AddScoped<IReceiptImageStorage, BlobStorageService>();
        container.AddScoped<IContainerRepository, ContainerRepository>();
        container.AddScoped<IReceiptRepository, ReceiptRepository>();
        container.AddScoped<IUserRepository, UserRepository>();
        container.AddScoped<IReceiptItemRepository, ReceiptItemRepository>();

        return container;
    }
}