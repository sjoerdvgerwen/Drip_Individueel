using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drip.Application.Entities;

namespace Drip.Webapp.Models
{
    public class CustomIncomeDateViewModel
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public List<Income> Incomes { get; set; }
    }
}
