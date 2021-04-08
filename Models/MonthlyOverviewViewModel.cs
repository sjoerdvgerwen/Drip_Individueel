using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drip.Application.Entities;

namespace Drip.Webapp.Models
{
    public class MonthlyOverviewViewModel
    {
        public Guid MonthID { get; set; }
        
        public List<Month> Months = new List<Month>();
        public string YearOfMonth { get; set; }
        
    }
}
