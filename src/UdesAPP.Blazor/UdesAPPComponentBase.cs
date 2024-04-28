using UdesAPP.Localization;
using Volo.Abp.AspNetCore.Components;

namespace UdesAPP.Blazor;

public abstract class UdesAPPComponentBase : AbpComponentBase
{
    protected UdesAPPComponentBase()
    {
        LocalizationResource = typeof(UdesAPPResource);
    }
}
