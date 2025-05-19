using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdesAPP.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace UdesAPP.Periods
{
    public interface IPeriodsCRUDAppService : IApplicationService,
        ICrudAppService< //Defines CRUD methods
        PeriodsDto, //Used to show classes
        Guid, //Primary key of the class entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        PeriodsDto>
    {
    }
}
