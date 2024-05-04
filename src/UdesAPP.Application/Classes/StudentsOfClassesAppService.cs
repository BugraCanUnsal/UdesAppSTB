using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdesAPP.Dtos;
using UdesAPP.Payments;
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

        public async Task<int> EnrollOfTheClass(int classId,int teacherId, decimal lessons)
        {
            var students = await GetStudentsByClassId(classId);
            if (students.Count > 0 && lessons > 0)
            {
                foreach (var student in students)
                {
                    Payment payment = await _paymentsManager.EnrollForStudent(student.Id, lessons);
                    if (payment == null)
                    {
                        return student.Id;
                    }
                }
            }
            else
            {
                return -1;
            }
            return 0;
        }
        public async Task EnrollOfTheStudent(int studentId, decimal lessons)
        {
            await _paymentsManager.EnrollForStudent(studentId, lessons);
        }

        public async Task<List<StudentDto>> GetAllPrivateClassStudents()
        {
            List<Student> students = await _studentsManager.GetAllPrivateClassStudents();
            return ObjectMapper.Map<List<Student>, List<StudentDto>>(students);
        }
    }
}
