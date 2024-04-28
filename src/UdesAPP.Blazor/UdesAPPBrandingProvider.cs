using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Ui.Branding;

namespace UdesAPP.Blazor;

[Dependency(ReplaceServices = true)]
public class UdesAPPBrandingProvider : DefaultBrandingProvider
{
    //You can inject services here...
    public override string AppName => "UDES İNGİLİZCE";
    public override string? LogoUrl => "/images/logo/udes/udes-logo.png";
    public override string? LogoReverseUrl => "/images/logo/udes/udes-logo.png";
}
