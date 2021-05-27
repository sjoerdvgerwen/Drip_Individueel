using Drip.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drip.Webapp.Models.MonthModels
{
    public class DeleteMonthViewModel
    {
        public List<Month> Months { get; set; }

        public Guid MonthId { get; set; }
    }
}
