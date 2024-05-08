using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace UdesAPP.Students
{
    [Authorize("UdesAPP.HostPermission")]
    public class PotentialStudentsCRUDAppService :
        CrudAppService<
            PotentialStudent,
            PotentialStudentsDto,
            int,
            PagedAndSortedResultRequestDto,
            PotentialStudentsDto>,
        IPotentialStudentsCRUDAppService
    {
        public PotentialStudentsCRUDAppService(IRepository<PotentialStudent, int> repository) 
            : base(repository)
        {
        }

        public async Task<List<PotentialStudentsDto>> GetAllPotentialStudentsAsync()
        {
            List<PotentialStudent> potentialStudents = await Repository.GetListAsync();
            return ObjectMapper.Map<List<PotentialStudent>, List<PotentialStudentsDto>>(potentialStudents);
        }

        public async Task UpdateNoteOfStudent(PotentialStudentsDto potentialStudentsDto)
        {
            List<PotentialStudent> potStudents = await Repository.GetListAsync();
            PotentialStudent student = potStudents.Find(x => x.Id == potentialStudentsDto.Id);
            if (student != null)
            {
                student.Note = potentialStudentsDto.Note;
                PotentialStudent potentialStudent = await Repository.UpdateAsync(student);
            }            
        }
    }
}
