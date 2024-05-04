using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace UdesAPP.Classes
{
    public class AllClassesDto : AuditedEntityDto<int>
    {
        public string ClassName { get; set; }
        public int TeacherId { get; set; }
        public int BookId { get; set; }
        public int DaysAndTimesOfWeekId { get; set; }
    }
}
