using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text;
using UdesAPP.GeneralEnums;

namespace UdesAPP.Students
{
    public class CreateUpdateStudentsDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        [Required]
        [StringLength(128)]
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string? GSM { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public Guid ClassId { get; set; }
        public Gender? Gender { get; set; }
        [Required]
        public StudentState IsActive { get; set; } = StudentState.Pasif;
        public StudentType? Type { get; set; } = StudentType.Belirsiz;
        public decimal GroupLessonFee { get; set; }
        public decimal IndividualLessonFee { get; set; }
        public string? Photograph { get; set; }
    }
}
