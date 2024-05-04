using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace UdesAPP.Classes
{
    public class Class : AuditedAggregateRoot<int>
    {
        public string ClassName { get; set; }
        public int TeacherId { get; set; }
        public int BookId { get; set; }
        public int DaysAndTimesOfWeekId { get; set; }
    }
}
