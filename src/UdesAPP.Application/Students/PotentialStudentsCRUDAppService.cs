using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace UdesAPP.Students
{
    public class PotentialStudentsCRUDAppService :
        CrudAppService<
            PotentialStudent,
            PotentialStudentsDto,
            int,
            PagedAndSortedResultRequestDto,
            PotentialStudentsDto>,
        IPotentialStudentsCRUDAppService
    {
        public PotentialStudentsCRUDAppService(IRepository<PotentialStudent, int> repository) 
            : base(repository)
        {
        }
    }
}
