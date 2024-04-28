using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdesAPP.Repositories;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace UdesAPP.Students
{
    public class StudentAppService :
        CrudAppService<
            Student,
            StudentDto,
            int,
            PagedAndSortedResultRequestDto,
            CreateUpdateStudentsDto>,
        IStudentAppService
    {
        public StudentAppService(IRepository<Student,int> repository) 
            : base(repository)
        {

        }
    }
}
