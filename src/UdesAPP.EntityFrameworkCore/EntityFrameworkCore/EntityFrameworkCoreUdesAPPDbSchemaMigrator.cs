using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UdesAPP.Data;
using Volo.Abp.DependencyInjection;

namespace UdesAPP.EntityFrameworkCore;

public class EntityFrameworkCoreUdesAPPDbSchemaMigrator
    : IUdesAPPDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreUdesAPPDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the UdesAPPDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<UdesAPPDbContext>()
            .Database
            .MigrateAsync();
    }
}
