using UdesAPP.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace UdesAPP.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class UdesAPPController : AbpControllerBase
{
    protected UdesAPPController()
    {
        LocalizationResource = typeof(UdesAPPResource);
    }
}
