using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace UdesAPP.Params
{
    public class ParametersCRUDAppService :
        CrudAppService<
            Param,
            ParametersDto,
            int,
            PagedAndSortedResultRequestDto,
            ParametersDto>,
        IParametersCRUDAppService
    {
        public ParametersCRUDAppService(IRepository<Param, int> repository) : 
            base(repository)
        {
        }
    }
}
