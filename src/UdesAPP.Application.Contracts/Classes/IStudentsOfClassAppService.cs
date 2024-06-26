﻿using System;
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
        Task<List<StudentsOfClassDto>> GetStudentsByClassId(int classId);
        Task<bool> DeleteStudentFromClass(StudentsOfClassDto deletingStudent);
        Task<int> EnrollOfTheClass(int classId,int teacherId, decimal lessons);
        Task<List<StudentDto>> GetAllPrivateClassStudents();
        Task EnrollOfTheStudent(int studentId, decimal lessons);
    }
}
