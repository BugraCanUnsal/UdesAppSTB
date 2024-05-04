using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace UdesAPP.Students
{
    public class PotentialStudent : AuditedAggregateRoot<int>
    {
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string GSM { get; set; }
        public string EMail { get; set; }
        public string Note { get; set; }
        public bool PotGroup { get; set; }
        public bool PotIndividual { get; set; }
        public bool WeekDays { get; set; }
        public bool Weekends { get; set; }
        public decimal GroupLessonFee { get; set; }
        public decimal IndividualLessonFee { get; set; }
    }
}
