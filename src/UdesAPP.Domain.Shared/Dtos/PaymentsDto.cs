﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Json.SystemTextJson.JsonConverters;

namespace UdesAPP.Dtos
{
    public class PaymentsDto
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public decimal HourBalance { get; set; }
        public decimal FeeBalance { get; set; }
        public bool IsActive { get; set; }
    }
}
