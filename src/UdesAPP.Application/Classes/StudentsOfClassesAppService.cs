using Microsoft.AspNetCore.Authorization;
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
    [Authorize("UdesAPP.HostPermission")]
    public class StudentsOfClassesAppService(
        StudentsManager studentsManager,
        PaymentsManager paymentsManager)
        : ApplicationService, IStudentsOfClassAppService
    {
        public async Task<bool> DeleteStudentFromClass(StudentsOfClassDto deletingStudent)
        {
            var student = ObjectMapper.Map<StudentsOfClassDto, Student>(deletingStudent);
            return await studentsManager.DeleteStudentFromClass(student);
        }

        public async Task<List<StudentsOfClassDto>> GetStudentsByClassId(Guid classId)
        {
            var students =  await studentsManager.GetStudentsByClassId(classId);
            return ObjectMapper.Map<List<Student>, List<StudentsOfClassDto>>(students);
        }

        public async Task<char> EnrollOfTheClass(Guid classId,Guid teacherId, decimal lessons)
        {
            var students = await GetStudentsByClassId(classId);
            if (students.Count > 0 && lessons > 0)
            {
                foreach (var student in students)
                {
                    Payment payment = await paymentsManager.EnrollForStudent(student.Id, lessons);
                    if (payment == null)
                    {
                        return '0';
                    }
                }
            }
            else
            {
                return '1';
            }
            return '2';
        }
        public async Task EnrollOfTheStudent(Guid studentId, decimal lessons)
        {
            await paymentsManager.EnrollForStudent(studentId, lessons);
        }

        public async Task<List<StudentDto>> GetAllPrivateClassStudents()
        {
            List<Student> students = await studentsManager.GetAllPrivateClassStudents();
            return ObjectMapper.Map<List<Student>, List<StudentDto>>(students);
        }
    }
}
