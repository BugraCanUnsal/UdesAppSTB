using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace UdesAPP.Teachers
{
    public class TeachersCRUIDAppService :
        CrudAppService<
            Teacher,
            TeacherDto,
            int,
            PagedAndSortedResultRequestDto,
            TeacherDto>,
        ITeachersCRUIDAppService
    {
        public TeachersCRUIDAppService(IRepository<Teacher, int> repository) 
            : base(repository)
        {
        }
    }
}
