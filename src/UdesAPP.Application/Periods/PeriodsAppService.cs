using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdesAPP.Dtos;
using UdesAPP.Repositories;
using Volo.Abp.Application.Services;

namespace UdesAPP.Periods
{
    public class PeriodsAppService : ApplicationService, IPeriodsAppService
    {
        private readonly PeriodsManager _periodsManager;
        public PeriodsAppService(PeriodsManager periodsManager)
        {
            _periodsManager = periodsManager;
        }
        public async Task<List<PeriodDto>> GetAllPeriods()
        {
            return await _periodsManager.GetAllPeriodsAsync();
        }
    }
}
