using Drip.Application.Entities;
using Drip.Webapp.Models.MonthModels;
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
                    return RedirectToAction("SuccesfullCreation", model);
                }
                else
                {
                    model.ProblemOccured = true;
                }
            }

            return View(model);
        }

        public IActionResult Delete(DeleteMonthViewModel model)
        {
            List<Month> months = _logic.GetAllCategories();

            model.Months = months;

            if (model.MonthId != Guid.Empty)
            {
                _logic.DeleteMonth(model.MonthId);
                return RedirectToAction("SuccesfullDelete", model);
            }

            return View(model); 
        }

        public IActionResult SuccesfullCreation(NewMonthViewModel model)
        {
            return View(model);
        }

        public IActionResult SuccesfullDelete(DeleteMonthViewModel model)
        {
            return View(model);
        }
    }
}
