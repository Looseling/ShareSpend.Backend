using Microsoft.Extensions.DependencyInjection;
using ShareSpend.Application.IRepository;
using ShareSpend.Application.Services.Receipt;

namespace SplitWise.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection container)
    {
        container.AddScoped<IReceiptService, ReceiptService>();
        return container;
    }
}