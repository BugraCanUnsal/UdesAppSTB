using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdesAPP.GeneralEnums;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace UdesAPP.Teachers
{
    public class Teacher : AuditedAggregateRoot<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string GSM { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime? Birthdate { get; set; }
        public string GraduatedFrom { get; set; }
        public Gender? Gender { get; set; }
    }
}
