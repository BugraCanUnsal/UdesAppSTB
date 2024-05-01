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
        private readonly PaymentsManager _paymentsManager;

        public StudentsOfClassesAppService(StudentsManager studentsManager,
            PaymentsManager paymentsManager)
        {
            _studentsManager = studentsManager;
            _paymentsManager = paymentsManager;
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

        public async Task EnrollOfTheClass(int classId, int lessons)
        {
            var students = await GetStudentsByClassId(classId);
            if (students.Count > 0 && lessons > 0)
            {
                foreach (var student in students)
                {
                    await _paymentsManager.EnrollForStudent(student.Id, lessons);
                }
            }            
        }
    }
}
