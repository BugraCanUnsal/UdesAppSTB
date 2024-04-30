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
    public class TeachersCRUDAppService :
        CrudAppService<
            Teacher,
            TeacherDto,
            int,
            PagedAndSortedResultRequestDto,
            TeacherDto>,
        ITeachersCRUDAppService
    {
        public TeachersCRUDAppService(IRepository<Teacher, int> repository) 
            : base(repository)
        {
        }

        public async Task<List<TeacherDto>> GetAllTeachersAsync()
        {
            List<Teacher> teachers = await Repository.GetListAsync();
            return ObjectMapper.Map<List<Teacher>, List<TeacherDto>>(teachers);
        }
    }
}
