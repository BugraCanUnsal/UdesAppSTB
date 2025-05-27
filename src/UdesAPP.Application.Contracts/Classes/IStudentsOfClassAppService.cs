using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdesAPP.Dtos;
using UdesAPP.Students;
using Volo.Abp.Application.Services;

namespace UdesAPP.Classes
{
    public interface IStudentsOfClassAppService : IApplicationService
    {
        Task<List<StudentsOfClassDto>> GetStudentsByClassId(Guid classId);
        Task<bool> DeleteStudentFromClass(StudentsOfClassDto deletingStudent);
        Task<char> EnrollOfTheClass(Guid classId,Guid teacherId, decimal lessons);
        Task<List<StudentDto>> GetAllPrivateClassStudents();
        Task EnrollOfTheStudent(Guid studentId, decimal lessons);
    }
}
