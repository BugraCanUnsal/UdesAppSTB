﻿using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdesAPP.Classes;
using UdesAPP.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace UdesAPP.Periods
{
    [Authorize("UdesAPP.HostPermission")]
    public class PeriodsCRUDAppService : 
        CrudAppService<
            Period,
            PeriodsDto,
            Guid,
            PagedAndSortedResultRequestDto,
            PeriodsDto>,
            IPeriodsCRUDAppService
    {
        public PeriodsCRUDAppService(IRepository<Period, Guid> repository)
            : base(repository)
        {

        }
    }
}
