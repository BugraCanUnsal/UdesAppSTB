using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UdesAPP.GeneralEnums;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities.Auditing;

namespace UdesAPP.Teachers
{
    public class TeacherDto : AuditedEntityDto<Guid>
    {
        [Required(ErrorMessage = "İsim alanı zorunludur.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soy Adı alanı zorunludur.")]
        public string Surname { get; set; }
        public string GSM { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime? Birthdate { get; set; }
        public string GraduatedFrom { get; set; }
        public Gender? Gender { get; set; }
        public decimal GroupLessonFee { get; set; }
        public decimal IndividualLessonFee { get; set; }
        public decimal Debt { get; set; }
    }
}
