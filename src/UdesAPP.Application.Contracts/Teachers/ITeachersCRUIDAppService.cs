using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace UdesAPP.Teachers
{
    public interface ITeachersCRUIDAppService : IApplicationService,
        ICrudAppService< //Defines CRUD methods
        TeacherDto, //Used to show books
        int, //Primary key of the book entity
        PagedAndSortedResultRequestDto,
        TeacherDto> //Used for paging/sorting
    {
    }
}
