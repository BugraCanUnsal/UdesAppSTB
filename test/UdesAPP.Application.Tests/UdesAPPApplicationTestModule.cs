using Volo.Abp.Modularity;

namespace UdesAPP;

[DependsOn(
    typeof(UdesAPPApplicationModule),
    typeof(UdesAPPDomainTestModule)
)]
public class UdesAPPApplicationTestModule : AbpModule
{

}
