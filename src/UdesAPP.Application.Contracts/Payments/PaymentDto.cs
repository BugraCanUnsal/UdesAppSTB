using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities.Auditing;

namespace UdesAPP.Payments
{
    public class PaymentDto : AuditedEntityDto<Guid>
    {
        public Guid StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public decimal HourBalance { get; set; }
        public decimal FeeBalance { get; set; }
        public bool IsActive { get; set; }
    }
}
