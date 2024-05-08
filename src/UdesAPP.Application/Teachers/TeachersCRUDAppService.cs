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

namespace UdesAPP.Teachers
{
    [Authorize("UdesAPP.HostPermission")]
    public class TeachersCRUDAppService :
        CrudAppService<
            Teacher,
            TeacherDto,
            int,
            PagedAndSortedResultRequestDto,
            TeacherDto>,
        ITeachersCRUDAppService
    {
        private readonly TeachersManager _teachersManager;
        public TeachersCRUDAppService(IRepository<Teacher, int> repository, TeachersManager teachersManager) 
            : base(repository)
        {
            _teachersManager = teachersManager;
        }

        public async Task<List<TeacherDto>> GetAllTeachersAsync()
        {
            List<Teacher> teachers = await Repository.GetListAsync();
            return ObjectMapper.Map<List<Teacher>, List<TeacherDto>>(teachers);
        }
        public async Task EnrollForTeacherById(int teacherId, decimal lessons)
        {
            await _teachersManager.EnrollForTeacherById(teacherId, lessons);
        }
    }
}
