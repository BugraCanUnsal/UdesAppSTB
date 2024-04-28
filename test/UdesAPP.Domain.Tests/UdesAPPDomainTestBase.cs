using Volo.Abp.Modularity;

namespace UdesAPP;

/* Inherit from this class for your domain layer tests. */
public abstract class UdesAPPDomainTestBase<TStartupModule> : UdesAPPTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
