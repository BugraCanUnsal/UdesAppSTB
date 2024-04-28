using System;
using System.Collections.Generic;
using System.Text;

namespace UdesAPP.Dtos
{
    public class PeriodDto
    {
        public int Id { get; set; }
        public string  Description { get; set; }
        public int? HoursPerWeek { get; set; }
    }
}
