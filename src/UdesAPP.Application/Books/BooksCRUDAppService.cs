using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdesAPP.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace UdesAPP.Books
{
    [Authorize("UdesAPP.HostPermission")]
    public class BooksCRUDAppService :
        CrudAppService<
            Book,
            BooksDto,
            Guid,
            PagedAndSortedResultRequestDto,
            BooksDto>,
        IBooksCRUDAppService
    {
        public BooksCRUDAppService(IRepository<Book, Guid> repository) 
            : base(repository)
        {
        }

        public async Task<List<BooksDto>> GetAllBooksAsync()
        {
            List<Book> books = await Repository.GetListAsync();
            return ObjectMapper.Map<List<Book> , List<BooksDto>>(books);
        }
    }
}
