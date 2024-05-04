using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace UdesAPP.Periods
{
    public class Period : AuditedAggregateRoot<int>
    {
        public string Description { get; set; }
        public int HoursPerWeek { get; set; }
    }
}
