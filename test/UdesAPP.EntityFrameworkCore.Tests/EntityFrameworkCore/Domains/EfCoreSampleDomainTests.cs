using UdesAPP.Samples;
using Xunit;

namespace UdesAPP.EntityFrameworkCore.Domains;

[Collection(UdesAPPTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<UdesAPPEntityFrameworkCoreTestModule>
{

}
