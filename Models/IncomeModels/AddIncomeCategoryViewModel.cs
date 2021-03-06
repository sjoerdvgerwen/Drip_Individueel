using Drip.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drip.Webapp.Models.IncomeModels
{
    public class AddIncomeCategoryViewModel
    {
        public List<Category> categories = new List<Category>();

        public Guid CategoryId { get; set; }

        public Guid IncomeId { get; set; }

        public string CategoryName { get; set; }
    }
}
