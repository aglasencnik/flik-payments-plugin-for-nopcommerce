using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using Nop.Plugin.Payments.Flik.Factories;
using Nop.Plugin.Payments.Flik.Services;

namespace Nop.Plugin.Payments.Flik.Infrastructure;

public class NopStartup : INopStartup
{
    public int Order => 1;

    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        // Services
        services.AddScoped<IConfigurationService, ConfigurationService>();
        services.AddScoped<IFlikPaymentProcessor, FlikPaymentProcessor>();
        services.AddScoped<IFlikPaymentService, FlikPaymentService>();

        // Factories
        services.AddScoped<IConfigurationFactory, ConfigurationFactory>();
    }

    public void Configure(IApplicationBuilder application)
    {
    }
}
