using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drip.Application.Entities;

namespace Drip.Webapp.Models
{
    public class MonthDetailsViewModel
    {
        public MonthDetailsViewModel(Month month)
        {
            MonthID = month.MonthID;
            NameOfMonth = month.NameOfMonth;
            YearOfMonth = month.YearOfMonth;
        }
        public Guid MonthID { get; set; }

        public string NameOfMonth { get; set; }

        public int YearOfMonth { get; set; }


    }
}
