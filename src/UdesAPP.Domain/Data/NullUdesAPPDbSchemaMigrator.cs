using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace UdesAPP.Data;

/* This is used if database provider does't define
 * IUdesAPPDbSchemaMigrator implementation.
 */
public class NullUdesAPPDbSchemaMigrator : IUdesAPPDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
