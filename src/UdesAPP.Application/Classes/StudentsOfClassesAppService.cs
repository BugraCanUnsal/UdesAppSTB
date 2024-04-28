using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdesAPP.Dtos;
using UdesAPP.Repositories;
using UdesAPP.Students;
using Volo.Abp.Application.Services;
using Volo.Abp.ObjectMapping;

namespace UdesAPP.Classes
{
    public class StudentsOfClassesAppService : ApplicationService, IStudentsOfClassAppService
    {
        private readonly StudentsManager _studentsManager;

        public StudentsOfClassesAppService(StudentsManager studentsManager)
        {
            _studentsManager = studentsManager;
        }

        public async Task<bool> DeleteStudentFromClass(StudentsOfClassDto deletingStudent)
        {
            var student = ObjectMapper.Map<StudentsOfClassDto, Student>(deletingStudent);
            return await _studentsManager.DeleteStudentFromClass(student);
        }

        public async Task<List<StudentsOfClassDto>> GetStudentsByClassId(int classId)
        {
            return await _studentsManager.GetStudentsByClassId(classId);
        }
    }
}
