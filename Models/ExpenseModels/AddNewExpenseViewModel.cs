using Drip.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drip.Webapp.Models.ExpenseModels
{
    public class AddNewExpenseViewModel
    {
        public List<Category> Categories { get; set; }
        public Guid CategoryId { get; set; }
        public Guid ExpenseId { get; set; }
        public double Amount { get; set; }
        public DateTime CreationTime { get; set; }
        public bool IsChecked { get; set; }
        public string Description { get; set; }
    }
}
