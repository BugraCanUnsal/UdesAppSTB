﻿using Microsoft.AspNetCore.Authorization;
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
    [Authorize("UdesAPP.HostPermission")]
    public class ParametersCRUDAppService :
        CrudAppService<
            Param,
            ParametersDto,
            Guid,
            PagedAndSortedResultRequestDto,
            ParametersDto>,
        IParametersCRUDAppService
    {
        public ParametersCRUDAppService(IRepository<Param, Guid> repository) : 
            base(repository)
        {
        }
    }
}
