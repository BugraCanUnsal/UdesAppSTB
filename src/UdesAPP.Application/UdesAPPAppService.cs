using System;
using System.Collections.Generic;
using System.Text;
using UdesAPP.Localization;
using Volo.Abp.Application.Services;

namespace UdesAPP;

/* Inherit your application services from this class.
 */
public abstract class UdesAPPAppService : ApplicationService
{
    protected UdesAPPAppService()
    {
        LocalizationResource = typeof(UdesAPPResource);
    }
}
