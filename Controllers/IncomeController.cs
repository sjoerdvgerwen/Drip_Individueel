using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drip.Application.Interfaces;
using Drip.Webapp.Models.IncomeModels;
using Drip.Application.Entities;
using Drip.Application.Logic;


namespace Drip.Webapp.Controllers
{
    public class IncomeController : Controller
    {
        private IncomeLogic _logic;
        private CategoryLogic _CLogic;

        public IncomeController(IncomeLogic logic, CategoryLogic cLogic)
        {
            _logic = logic;
            _CLogic = cLogic;
        }

        public IActionResult AddIncome(AddIncomeViewModel model)
        {
            bool IsChecked = model.IsChecked;
            DateTime CreationTime = model.CreationTime;

            if (model.Description != null)
            {
                if (model.IsChecked == true && _logic.OnlyCheckBoxIsChecked(IsChecked, CreationTime))
                {
                    Income income = new Income()
                    {
                        IncomeId = Guid.NewGuid(),
                        Amount = model.Amount,
                        TimeOfIncomeCreation = DateTime.Now,
                        Description = model.Description
                    };
                    model.IncomeId = income.IncomeId;
                    if (_logic.AddIncome(income))
                    {
                        return RedirectToAction("AddIncomeToCategory", model);
                    }
                    else
                    {
                        return RedirectToAction("Fail");
                    }
                }
            }

            if(model.Description != null) {
                if (_logic.OnlyCustomTimeStampIsFilledIn(IsChecked, CreationTime))
                {
                    Income customTimeIncome = new Income()
                    {
                        IncomeId = Guid.NewGuid(),
                        Amount = model.Amount,
                        TimeOfIncomeCreation = model.CreationTime,
                        Description = model.Description
                    };
                    model.IncomeId = customTimeIncome.IncomeId;
                    if (_logic.AddIncome(customTimeIncome))
                    {
                        return RedirectToAction("AddIncomeToCategory", model);
                    }
                    else
                    {
                        return RedirectToAction("Fail");
                    }
                }
            }
            return View();
        }

        public IActionResult AddIncomeToCategory(AddIncomeViewModel model)
        {
            List<Category> _categories = _CLogic.GetAllCategories();
            
            model.Categories = _categories;

            if (model.CategoryId != Guid.Empty)
            {
                _CLogic.AddIncomeToCategory(model.CategoryId, model.IncomeId);
                return RedirectToAction("Succes");
            }
            return View(model);
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
