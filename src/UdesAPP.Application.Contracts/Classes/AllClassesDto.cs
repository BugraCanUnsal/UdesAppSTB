using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace UdesAPP.Classes
{
    public class AllClassesDto : AuditedEntityDto<Guid>
    {
        public string ClassName { get; set; }
        public Guid TeacherId { get; set; }
        public Guid BookId { get; set; }
        public int DaysAndTimesOfWeekId { get; set; }
    }
}
