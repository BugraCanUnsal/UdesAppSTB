using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace UdesAPP.Students
{
    public interface IPotentialStudentsCRUDAppService : IApplicationService,
        ICrudAppService<
            PotentialStudentsDto,
            int,
            PagedAndSortedResultRequestDto,
            PotentialStudentsDto>
    {
    }
}
