using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdesAPP.Payments;
using UdesAPP.Teachers;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace UdesAPP.Repositories
{
    public class TeachersManager : IDomainService
    {
        private readonly IRepository<Teacher> _teacherRepository;

        public TeachersManager(IRepository<Teacher> teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task EnrollForTeacherById(Guid teacherId, decimal lesson)
        {
            List<Teacher> teachers = await _teacherRepository.GetListAsync();

            Teacher teacher = teachers.Find(x =>  x.Id == teacherId);
            if (teacher != null) {
                teacher.Debt += lesson;
                await _teacherRepository.UpdateAsync(teacher);
            }
        }
    }
}
