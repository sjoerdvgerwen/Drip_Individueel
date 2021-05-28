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
            Income income = new Income()
            {
                IncomeId = Guid.NewGuid(),
                Amount = model.Amount,
                TimeOfIncomeCreation = DateTime.Now,
                Description = model.Description
            };

            model.IncomeId = income.IncomeId;

            if (model.Description != null) 
            {
                if (_logic.AddIncome(income)) 
                {
                    return RedirectToAction("AddIncomeToCategory", model);
                }
                else
                {
                    return RedirectToAction("Fail");
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
                _CLogic.AddIncomeToCategory(model.CategoryId, model.IncomeId, model.CategoryName);
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

        //public string Result { get; set; }
        //public IActionResult AddIncomeCategoryForm(AddNewIncomeViewModel viewModel)
        //{
        //    List<Income> income = _incomeRepository.GetAllIncomes();

        //Application.Logic.CategoryLogic _logic = new Application.Logic.CategoryLogic();

        //    AddIncomeCategoryViewModel model = new AddIncomeCategoryViewModel()
        //    {
        //        CategoryId = Guid.NewGuid(),
        //        IncomeId = viewModel.IncomeId,
        //        IncomeCategory = viewModel.IncomeCategory,
        //       AllIncomes = income
        //    };

        //if (_logic.IsCategoryFilledIn(viewModel.IncomeCategory) && _logic.DoesCategoryHaveValue(viewModel.IncomeId))
        //{
        //    _incomeRepository.AddCategory(model.CategoryId, model.IncomeId, model.IncomeCategory);
        //}

        //    return RedirectToAction("Index", "Dashboard");
        // }

        //public IActionResult GetAllIncomes()
        //{
        //    List<Income> income = _logic.GetAllIncomes();
        //
        //    var ViewIncomes = new DashboardViewModel()
        //    {
        //       AllIncomes = income
        //   };

        //   return View(ViewIncomes);
        // }

    }
}
