using System.Threading.Tasks;

namespace UdesAPP.Data;

public interface IUdesAPPDbSchemaMigrator
{
    Task MigrateAsync();
}
