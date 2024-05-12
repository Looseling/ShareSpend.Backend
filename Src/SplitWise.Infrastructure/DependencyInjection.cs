using Microsoft.Extensions.DependencyInjection;
using ShareSpend.Application.IRepository;
using ShareSpend.Infrastructure.Data.Repository;

namespace SplitWise.AddInfrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection container)
    {
        container.AddScoped<IReceiptContainerRepository, ReceiptContainerRepository>();
        container.AddScoped<IReceiptRepository, ReceiptRepository>();
        container.AddScoped<IUserRepository, UserRepository>();
        container.AddScoped<IReceiptItemRepository, ReceiptItemRepository>();

        return container;
    }
}