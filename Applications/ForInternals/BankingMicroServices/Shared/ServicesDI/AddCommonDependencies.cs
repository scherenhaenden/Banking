using Microsoft.Extensions.DependencyInjection;

namespace Shared.ServicesDI;

public class AddCommonDependencies
{
    public IServiceCollection AddAll(IServiceCollection services)
    {
        return services;
    }
}