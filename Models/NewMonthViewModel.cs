using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drip.Webapp.Models
{
    public class NewMonthViewModel
    {
        public Guid MonthID { get; set; }

        public string NameOfMonth { get; set; }

        public int YearOfMonth { get; set; }

        public DateTime StartOfMonth { get; set; }

        public DateTime EndOfMonth { get; set; }
    }
}
