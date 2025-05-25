using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace UdesAPP.Payments
{
    public class Payment : AuditedAggregateRoot<Guid>
    {
        public Guid StudentId { get; set; }
        public string StudentName { get; set;}
        public string StudentSurname { get; set;}
        public decimal HourBalance { get; set; }
        public decimal FeeBalance { get; set; }
        public bool IsActive { get; set; }
    }
}
