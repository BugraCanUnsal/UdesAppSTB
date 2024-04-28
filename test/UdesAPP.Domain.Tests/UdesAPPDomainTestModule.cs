using Volo.Abp.Modularity;

namespace UdesAPP;

[DependsOn(
    typeof(UdesAPPDomainModule),
    typeof(UdesAPPTestBaseModule)
)]
public class UdesAPPDomainTestModule : AbpModule
{

}
