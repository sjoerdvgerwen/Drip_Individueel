using Drip.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drip.Webapp.Models.IncomeModels
{
    public class AddIncomeViewModel
    {
        public List<Category> Categories = new List<Category>();
        public Guid IncomeId { get; set; }

        public double Amount { get; set; }

        public DateTime TimeOfIncomeCreation { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }
        public Guid CategoryId { get; internal set; }
    }
}
