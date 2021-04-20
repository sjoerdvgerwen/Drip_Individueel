using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drip.Application.Entities;

namespace Drip.Webapp.Models
{
    public class GetAllIncomesViewModel
    {
        public List<Income> AllIncomes = new List<Income>();

        public List<Expense> AllExpenses = new List<Expense>();

        public List<Month> AllMonths = new List<Month>();
    }
}
