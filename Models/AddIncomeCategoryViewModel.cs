using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drip.Application.Entities;

namespace Drip.Webapp.Models
{
    public class AddIncomeCategoryViewModel
    {
        public List<Income> AllIncomes = new List<Income>();

        public string IncomeCategory { get; set; }

        public string Description { get; set; }
    }
}
