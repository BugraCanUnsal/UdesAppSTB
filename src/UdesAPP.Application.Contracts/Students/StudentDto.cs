using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UdesAPP.GeneralEnums;
using Volo.Abp.Application.Dtos;

namespace UdesAPP.Students
{
    public class StudentDto : AuditedEntityDto<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? GSM { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public int ClassId { get; set; }
        public Gender? Gender { get; set; }
        public StudentState IsActive { get; set; }
        public StudentType? Type { get; set; }
        public int? GroupLessonFee { get; set; }
        public int? IndividualLessonFee { get; set; }
        public string? Photograph { get; set; }
    }
}
