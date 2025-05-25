using AutoMapper.Internal.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using UdesAPP.Books;
using UdesAPP.Classes;
using UdesAPP.Dtos;
using UdesAPP.Periods;
using UdesAPP.Students;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace UdesAPP.Repositories
{
    public class StudentsManager : IDomainService
    {
        private readonly IRepository<Student> _studentRepository;
        private readonly ILogger<StudentsManager> _logger;
        public StudentsManager(
            IRepository<Student> studentRepository,
            ILogger<StudentsManager> logger
            )
        {
            _studentRepository = studentRepository;
            _logger = logger;
        }
        public async Task<List<Student>> GetStudentsByClassId(Guid classId)
        {
            return await _studentRepository.GetListAsync(x => x.ClassId == classId);
        }

        public async Task<bool> DeleteStudentFromClass(Student student)
        {
            try
            {
                if (student == null)
                    throw new ArgumentNullException(nameof(student));

                var myStudent = await _studentRepository.GetAsync(x => x.Id == student.Id);
                
                myStudent.ClassId = Guid.Empty;
                myStudent.Type = StudentType.Belirsiz;
                
                await _studentRepository.UpdateAsync(myStudent);
                return true;
            }
            catch (EntityNotFoundException)
            {
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Öğrenci sınıftan silinirken hata oluştu. Öğrenci ID: {StudentId}", student.Id);
                throw;
            }
        }
        public async Task<List<Student>> GetAllPrivateClassStudents()
        {
            return await _studentRepository.GetListAsync(
                x => x.IsActive == StudentState.Aktif && 
                     x.Type == StudentType.Özel
            );
        }

    }
}