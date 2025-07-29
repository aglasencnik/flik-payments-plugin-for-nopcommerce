using Nop.Plugin.Payments.Flik.Models;

namespace Nop.Plugin.Payments.Flik.Factories;

/// <summary>
/// Represents the configuration factory
/// </summary>
public interface IConfigurationFactory
{
    /// <summary>
    /// Prepares the configuration model for the payment plugin
    /// </summary>
    /// <returns>
    /// Configuration view model object.
    /// A task that represents the asynchronous operation.
    /// </returns>
    Task<ConfigurationVm> PrepareConfigurationModelAsync();
}
