﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drip.Application.Entities;

namespace Drip.Webapp.Models
{
    public class GetAllIncomesViewModel
    {
        public List<Income> AllIncomes = new List<Income>();
        public Guid IncomeId { get; set; }

        public double Amount { get; set; }

        public DateTime TimeOfIncomeCreation { get; set; }

        public string Description { get; set; }
    }
}