using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace UdesAPP.Books
{
    public interface IBooksCRUDAppService : IApplicationService,
        ICrudAppService<
            BooksDto,
            Guid,
            PagedAndSortedResultRequestDto,
            BooksDto>
    {
        Task<List<BooksDto>> GetAllBooksAsync();
    }
}
