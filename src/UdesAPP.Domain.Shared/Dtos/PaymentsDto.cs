using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Json.SystemTextJson.JsonConverters;

namespace UdesAPP.Dtos
{
    public class PaymentsDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public int? HourBalance { get; set; }
        public int? FeeBalance { get; set; }
        public bool IsActive { get; set; }
    }
}
