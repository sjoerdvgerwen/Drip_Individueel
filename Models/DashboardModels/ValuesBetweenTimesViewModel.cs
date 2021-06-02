using Drip.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drip.Webapp.Models.DashboardModels
{
    public class ValuesBetweenTimesViewModel
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public List<Income> Incomes = new List<Income>();
        public List<Expense> Expenses = new List<Expense>();
    }
}
