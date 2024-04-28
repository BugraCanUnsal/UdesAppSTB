using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdesAPP.Dtos;
using Volo.Abp.Application.Services;

namespace UdesAPP.Periods
{
    public interface IPeriodsAppService : IApplicationService
    {
        Task<List<PeriodDto>> GetAllPeriods();
    }
}
