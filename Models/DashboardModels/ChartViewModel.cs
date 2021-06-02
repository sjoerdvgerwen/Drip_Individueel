using Drip.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drip.Webapp.Models.DashboardModels
{
    public class ChartViewModel
    {
        public List<Income> IncomesPerMonth { get; set; }

        public List<Expense> ExpensesPerMonth { get; set; }

        public List<Double> Result { get; set; }
    }
}
