﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace UdesAPP.Params
{
    public class ParametersDto : AuditedEntityDto<Guid>
    {
        public string Paramtype { get; set; }
        public int ParamCode { get; set; }
        public string ParamDescription { get; set; }
        public string? ParamValue1 { get; set; }
        public string? ParamValue2 { get; set; }
        public string? ParamValue3 { get; set; }
        public string? ParamValue4 { get; set; } 
        public string? ParamValue5 { get; set; } 
    }
}
