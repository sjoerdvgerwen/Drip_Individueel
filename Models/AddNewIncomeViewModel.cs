using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drip.Webapp.Models
{
    public class AddNewIncomeViewModel
    {
        public Guid IncomeId { get; set; }

        public double Amount { get; set; }

        public DateTime TimeOfIncomeCreation { get; set; }

        public string Description { get; set; }

        public string IncomeCategory { get; set; }
    }
}
