using Drip.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drip.Webapp.Models.DashboardModels
{
    public class ChartViewModel
    {
        public List<Income> IncomesPerMonth { get; set; }
    }
}
