using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drip.Webapp.Models
{
    public class AddNewExpenseViewModel
    {
        public Guid ExpenseId { get; set; }

        public double Amount { get; set; }

        public DateTime TimeOfExpenseCreation { get; set; }

        public string Description { get; set; }
    }
}
