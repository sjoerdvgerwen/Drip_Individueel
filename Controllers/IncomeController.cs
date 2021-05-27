using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drip.Application.Interfaces;
using Drip.Webapp.Models;
using Drip.Application.Entities;

namespace Drip.Webapp.Controllers
{
    public class IncomeController : Controller
    {
        private readonly IIncomeRepository _incomeRepository;

        public IncomeController(IIncomeRepository incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }

        public IActionResult AddNewIncome()
        {
            return View();
        }

        public IActionResult AddIncome(AddNewIncomeViewModel model)
        {
            Income income = new Income()
            {
                IncomeId = Guid.NewGuid(),
                Amount = model.Amount,
                TimeOfIncomeCreation = DateTime.Now,
                Description = model.Description
            };

            model.IncomeId = income.IncomeId;

            _incomeRepository.AddIncome(income);

            return RedirectToAction("AddIncomeCategory", "Income");
        }

        public IActionResult AddIncomeCategory()
        {
            List<Income> income = _incomeRepository.GetAllIncomes();

            AddIncomeCategoryViewModel model = new AddIncomeCategoryViewModel()
            {
                AllIncomes = income,
            };

            return View(model);
        }
        public string Result { get; set; }
        public IActionResult AddIncomeCategoryForm(AddNewIncomeViewModel viewModel)
        {
            List<Income> income = _incomeRepository.GetAllIncomes();

            //Application.Logic.CategoryLogic _logic = new Application.Logic.CategoryLogic();

            AddIncomeCategoryViewModel model = new AddIncomeCategoryViewModel()
            {
                CategoryId = Guid.NewGuid(),
                IncomeId = viewModel.IncomeId,
                IncomeCategory = viewModel.IncomeCategory,
                AllIncomes = income
            };

            //if (_logic.IsCategoryFilledIn(viewModel.IncomeCategory) && _logic.DoesCategoryHaveValue(viewModel.IncomeId))
            //{
            //    _incomeRepository.AddCategory(model.CategoryId, model.IncomeId, model.IncomeCategory);
            //}

            return RedirectToAction("Index", "Dashboard");
        }

        public IActionResult GetAllIncomes()
        {
            List<Income> income = _incomeRepository.GetAllIncomes();

            var ViewIncomes = new DashboardViewModel()
            {
                AllIncomes = income
            };

            return View(ViewIncomes);
        }

    }
}
