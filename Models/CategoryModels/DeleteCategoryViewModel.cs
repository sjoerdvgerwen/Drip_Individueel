using Drip.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drip.Webapp.Models.CategoryModels
{
    public class DeleteCategoryViewModel
    {
        public Guid CategoryId { get; set; }

        public string CategoryName { get; set; }

        public List<Category> Categories { get; set; }
    }
}
