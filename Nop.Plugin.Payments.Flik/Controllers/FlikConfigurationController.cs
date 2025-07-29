using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Payments.Flik.Factories;
using Nop.Plugin.Payments.Flik.Models;
using Nop.Plugin.Payments.Flik.Services;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Payments.Flik.Controllers;

[AuthorizeAdmin]
[Area(AreaNames.ADMIN)]
[AutoValidateAntiforgeryToken]
public class FlikConfigurationController : BasePaymentController
{
    #region Fields

    private readonly IConfigurationFactory _configurationFactory;
    private readonly IConfigurationService _configurationService;
    private readonly INotificationService _notificationService;
    private readonly ILocalizationService _localizationService;

    #endregion

    #region Ctor

    public FlikConfigurationController(IConfigurationFactory configurationFactory,
        IConfigurationService configurationService,
        INotificationService notificationService,
        ILocalizationService localizationService)
    {
        _configurationFactory = configurationFactory;
        _configurationService = configurationService;
        _notificationService = notificationService;
        _localizationService = localizationService;
    }

    #endregion

    #region Methods

    [CheckPermission(StandardPermission.Configuration.MANAGE_PAYMENT_METHODS)]
    public async Task<IActionResult> Configure()
    {
        var model = await _configurationFactory.PrepareConfigurationModelAsync();
        return View($"{FlikPaymentDefaults.ViewsPath}/Configure.cshtml", model);
    }

    [HttpPost]
    [CheckPermission(StandardPermission.Configuration.MANAGE_PAYMENT_METHODS)]
    public async Task<IActionResult> Configure(ConfigurationVm model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await _configurationService.SaveConfigurationAsync(model);

        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Plugins.Saved"));

        return RedirectToAction("Configure");
    }

    #endregion
}
