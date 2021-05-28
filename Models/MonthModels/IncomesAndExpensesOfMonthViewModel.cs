using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drip.Webapp.Models.MonthModels
{
    public class IncomesAndExpensesOfMonthViewModel
    {
        public string IncomeDescription { get; set; }

        public double IncomeAmount { get; set; }

        public DateTime IncomeCreation { get; set; }

        public string ExpenseDescription { get; set; }

        public double ExpenseAmount { get; set; }

        public DateTime ExpenseCreation { get; set; }
        
    }
}
