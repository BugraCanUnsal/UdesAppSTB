using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace UdesAPP.Classes
{
    public class CreateUpdateAllClassesDto
    {
        [Required]
        [StringLength(150)]
        public string ClassName { get; set; }
        public Guid? TeacherId { get; set; }
        public Guid? BookId { get; set; }
        public int? DaysAndTimesOfWeekId { get; set; }
    }
}
