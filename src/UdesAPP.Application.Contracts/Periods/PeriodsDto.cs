using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Uow;

namespace UdesAPP.Periods
{
    public class PeriodsDto : AuditedEntityDto<Guid>
    {
        [Required(ErrorMessage = "Açıklama alanı zorunludur.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Haftalık Saat alanı zorunludur.")]
        public int? HoursPerWeek { get; set; }
    }
}
