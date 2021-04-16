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
            Income expense = new Income()
            {
                IncomeId = Guid.NewGuid(),
                Amount = model.Amount,
                TimeOfIncomeCreation = DateTime.Now,
                Description = model.Description
            };

            _incomeRepository.AddIncome(expense);

            return RedirectToAction("MonthlyOverview", "Dashboard");
        }

        public IActionResult GetAllIncomes()
        {
            List<Income> income = _incomeRepository.GetAllIncomes();

            var ViewIncomes = new GetAllIncomesViewModel()
            {
                AllIncomes = income
            };

            return View(ViewIncomes);
        }
    }
}
