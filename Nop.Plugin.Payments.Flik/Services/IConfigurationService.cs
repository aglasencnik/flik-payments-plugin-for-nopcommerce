using Nop.Plugin.Payments.Flik.Models;

namespace Nop.Plugin.Payments.Flik.Services;

/// <summary>
/// Represents the configuration service
/// </summary>
public interface IConfigurationService
{
    /// <summary>
    /// Saves the payment method configuration
    /// </summary>
    /// <param name="model">Configuration view model</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    Task SaveConfigurationAsync(ConfigurationVm model);
}
