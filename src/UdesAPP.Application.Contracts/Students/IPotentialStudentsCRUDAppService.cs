using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
        Task UpdateNoteOfStudent(PotentialStudentsDto potentialStudentsDto);
        Task<List<PotentialStudentsDto>> GetAllPotentialStudentsAsync();
    }
}
