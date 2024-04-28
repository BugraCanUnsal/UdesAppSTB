using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace UdesAPP.Students
{
    public interface IStudentAppService : IApplicationService,
        ICrudAppService< //Defines CRUD methods
        StudentDto, //Used to show books
        int, //Primary key of the book entity
        PagedAndSortedResultRequestDto,
        CreateUpdateStudentsDto> //Used for paging/sorting
    {
    }
}
