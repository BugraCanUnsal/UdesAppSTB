using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace UdesAPP.Students
{
    public class PotentialStudentsDto : AuditedEntityDto<int>
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
        public int GroupLessonFee { get; set; }
        public int IndividualLessonFee { get; set; }
    }
}
