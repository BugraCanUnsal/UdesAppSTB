using UdesAPP.Samples;
using Xunit;

namespace UdesAPP.EntityFrameworkCore.Applications;

[Collection(UdesAPPTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<UdesAPPEntityFrameworkCoreTestModule>
{

}
