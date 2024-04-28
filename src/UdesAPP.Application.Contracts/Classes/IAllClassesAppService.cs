using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace UdesAPP.Classes
{
    public interface IAllClassesAppService : IApplicationService,
        ICrudAppService< //Defines CRUD methods
        AllClassesDto, //Used to show classes
        int, //Primary key of the class entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateAllClassesDto>
    {
        Task<List<AllClassesDto>> GetAllClassesAsync();
    }
}
