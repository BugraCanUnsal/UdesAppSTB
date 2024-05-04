using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdesAPP.GeneralEnums;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Json.SystemTextJson.JsonConverters;

namespace UdesAPP.Students
{
    public class Student : AuditedAggregateRoot<int>
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? GSM { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public int ClassId { get; set; }
        public Gender? Gender { get; set; }
        public StudentState IsActive { get; set; }
        public StudentType? Type { get; set; }
        public decimal GroupLessonFee { get; set; }
        public decimal IndividualLessonFee { get; set; }
        public string? Photograph { get; set; }
    }
}
