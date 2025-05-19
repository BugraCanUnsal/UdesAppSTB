using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace UdesAPP.Params
{
    public interface IParametersCRUDAppService : IApplicationService,
        ICrudAppService<
            ParametersDto,
            Guid,
            PagedAndSortedResultRequestDto,
            ParametersDto>
    {
    }
}
