using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace UdesAPP.Params
{
    public class Param : AuditedAggregateRoot<Guid>
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
