using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace UdesAPP.Classes
{
    public class Class : AuditedAggregateRoot<Guid>
    {
        public string ClassName { get; set; }
        public Guid TeacherId { get; set; }
        public Guid BookId { get; set; }
        public int DaysAndTimesOfWeekId { get; set; }
    }
}
