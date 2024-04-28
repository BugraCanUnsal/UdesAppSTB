using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Uow;

namespace UdesAPP.Periods
{
    public class PeriodsDto : AuditedEntityDto<int>
    {
        public string Description { get; set; }
        public int? HoursPerWeek { get; set; }
    }
}
