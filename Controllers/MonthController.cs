using Drip.Application.Entities;
using Drip.Webapp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drip.Webapp.Controllers
{
    public class MonthController : Controller
    {
        private Application.Logic.MonthLogic _logic;
        public MonthController(Application.Logic.MonthLogic logic)
        {
            _logic = logic;
        }
        public IActionResult Create(NewMonthViewModel model)
        {
            Month month = new Month()
            {
                MonthID = Guid.NewGuid(),
                NameOfMonth = model.NameOfMonth,
                YearOfMonth = model.YearOfMonth,
                StartOfMonth = model.StartOfMonth,
                EndOfMonth = model.EndOfMonth
            };

            if (model.NameOfMonth != null)
            {
                if (_logic.CreateMonth(month))
                {
                    return RedirectToAction("Succes");
                }
                else
                {
                    return RedirectToAction("Fail");
                }
            }

            return View();
        }

        public IActionResult Fail()
        {

            return View();
        }

        public IActionResult Succes()
        {

            return View();
        }
    }
}
