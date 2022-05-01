using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Toolbelt.Blazor.CopyButtonizer;

namespace Toolbelt.Blazor.Extensions.DependencyInjection;

public static class CopyButtonizerDependencyInjection
{
    public static IServiceCollection AddCopyButtonizeOptions(this IServiceCollection services, Action<CopyButtonizeOptions>? configure)
    {
        services.TryAddScoped(serviceProvider =>
        {
            var options = new CopyButtonizeOptions();
            configure?.Invoke(options);
            return options;
        });
        return services;
    }
}
