using UdesAPP.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace UdesAPP.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(UdesAPPEntityFrameworkCoreModule),
    typeof(UdesAPPApplicationContractsModule)
    )]
public class UdesAPPDbMigratorModule : AbpModule
{
}
