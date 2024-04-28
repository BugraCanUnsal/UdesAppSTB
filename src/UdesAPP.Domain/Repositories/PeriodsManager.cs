using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdesAPP.Dtos;
using UdesAPP.Periods;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace UdesAPP.Repositories
{
    public class PeriodsManager : IDomainService
    {
        private readonly IRepository<Period> _periodsRepository;

        public PeriodsManager(IRepository<Period> studentRepository)
        {
            _periodsRepository = studentRepository;
        }

        public async Task<List<PeriodDto>> GetAllPeriodsAsync()
        {
            var _periods = await _periodsRepository.GetListAsync();

            var periods = _periods.Select(r => new PeriodDto()
            {
                Id = r.Id,
                Description = r.Description,
                HoursPerWeek = r.HoursPerWeek
            }).ToList();

            return await Task.FromResult(periods);
        }
    }
}
