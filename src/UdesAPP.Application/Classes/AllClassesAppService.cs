using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdesAPP.Students;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace UdesAPP.Classes
{
    [Authorize("UdesAPP.HostPermission")]
    public class AllClassesAppService :
        CrudAppService<
            Class,
            AllClassesDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateAllClassesDto>,
            IAllClassesAppService
    {
        private IRepository<Class> _classRepository;
        public AllClassesAppService(IRepository<Class, Guid> repository)
            : base(repository)
    {
            _classRepository = repository;
    }
        public async Task<List<AllClassesDto>> GetAllClassesAsync()
        {
            List<Class> classes = await _classRepository.GetListAsync();
            return ObjectMapper.Map<List<Class>, List<AllClassesDto>>(classes);
        }
    }
}
