using Volo.Abp.Modularity;

namespace UdesAPP;

public abstract class UdesAPPApplicationTestBase<TStartupModule> : UdesAPPTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
