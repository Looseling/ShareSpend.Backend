using Microsoft.Extensions.DependencyInjection;
using SplitWise.Application.Services.Authentication;

namespace SplitWise.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection container)
    {
        container.AddScoped<IAuthenticationService, AuthenticationService>();

        return container;
    }

}