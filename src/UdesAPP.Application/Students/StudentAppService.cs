using Microsoft.AspNetCore.Authorization;
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
    [Authorize("UdesAPP.HostPermission")]
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
        public async Task<List<StudentDto>> GetAllStudentsAsync()
        {
            List<Student> students = await Repository.GetListAsync();
            return ObjectMapper.Map<List<Student>, List<StudentDto>>(students);
        }

    }
}
