using AutoMapper.Internal.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdesAPP.Books;
using UdesAPP.Classes;
using UdesAPP.Dtos;
using UdesAPP.Periods;
using UdesAPP.Students;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace UdesAPP.Repositories
{
    public class StudentsManager : IDomainService
    {
        private readonly IRepository<Student> _studentRepository;

        public StudentsManager(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<StudentsOfClassDto>> GetStudentsByClassId(int classId)
        {
            var students = await _studentRepository.GetListAsync();

            var studentsOfClass = students.FindAll(x => x.ClassId == classId).Select(r => new StudentsOfClassDto()
            {
                Id = r.Id,
                Name = r.Name,
                Surname = r.Surname
            }).ToList();

            return await Task.FromResult(studentsOfClass);
        }
        public async Task<bool> DeleteStudentFromClass(Student student)
        {
            var updatingStudent = await _studentRepository.GetListAsync();
            Student myStudent = updatingStudent.Find(x => x.Id == student.Id);
            bool isUpdated = true;
            if (myStudent != null)
            {
                myStudent.ClassId = 0;
                myStudent.Type = (int)StudentType.Belirsiz;
                var updatedStudent = await _studentRepository.UpdateAsync(myStudent);
                if (updatedStudent == null)
                {
                    isUpdated = false;
                }
            }
            return await Task.FromResult(isUpdated);
        }

    }
}
