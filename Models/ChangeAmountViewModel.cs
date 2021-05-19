using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drip.Application.Entities;

namespace Drip.Webapp.Models
{
    public class ChangeAmountViewModel
    {
        public ChangeAmountViewModel(Income income)
        {
            IncomeId = income.IncomeId;
            Description = income.Description;
            Amount = income.Amount;
            Time = income.TimeOfIncomeCreation;
        }
        public Guid IncomeId { get; set; }

        public string Description { get; set; }

        public Double Amount { get; set; }

        public DateTime Time { get; set; }
    }
}
