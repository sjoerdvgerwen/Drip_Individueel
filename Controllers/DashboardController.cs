using Drip.Application.Entities;
using Drip.Application.Interfaces;
using Drip.Webapp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drip.Webapp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;
        private readonly IIncomeRepository _incomeRepository;
        private readonly IExpenseRepository _expenseRepository;

        public DashboardController(IDashboardRepository dashboardRepository, IIncomeRepository incomeRepository, IExpenseRepository expenseRepository)
        {
            _dashboardRepository = dashboardRepository;
            _incomeRepository = incomeRepository;
            _expenseRepository = expenseRepository;
        }

        public IActionResult Index()
        {
            List<Income> income = _incomeRepository.GetAllIncomes();
            List<Expense> expenses = _expenseRepository.GetAllExpenses();
            List<Month> months = _dashboardRepository.GetAllMonths();

            var viewModel = new DashboardViewModel()
            {
                AllIncomes = income,
                AllExpenses = expenses,
                AllMonths = months
            };

            return View(viewModel);
        }

        public IActionResult MonthlyOverview()
        {
            List<Month> months = _dashboardRepository.GetAllMonths();

            var ListOfMonths = new MonthlyOverviewViewModel()
            {
                Months = months
            };

            return View(ListOfMonths);
        }

        public IActionResult GetMonth(Guid MonthID)
        {
            Month month = _dashboardRepository.GetMonthDetails(MonthID);

            MonthDetailsViewModel MonthModel = new MonthDetailsViewModel(month);

            return View("GetMonthDetails", MonthModel);
        }


        public IActionResult AddNewMonth()
        {
            return View();
        }


        public IActionResult AddMonth (NewMonthViewModel model)
        {
            Month newMonth = new Month()
            {
                MonthID = Guid.NewGuid(),
                NameOfMonth = model.NameOfMonth,
                YearOfMonth = model.YearOfMonth,
                StartOfMonth = model.StartOfMonth,
                EndOfMonth = model.EndOfMonth   
            };

            _dashboardRepository.AddNewMonth(newMonth);
            
            return RedirectToAction("Index");
        }


        public IActionResult DeleteMonth()
        {
            List<Month> months = _dashboardRepository.GetAllMonths();

            var viewModel = new DeleteMonthViewModel { monthsModel = months };

            return View(viewModel);
        }

        public IActionResult DeleteById (Guid monthID)
        {
            Month selectedMonth = _dashboardRepository.DeleteMonth(monthID);

            selectedMonth.MonthID = monthID;

            return RedirectToAction("DeleteMonth", selectedMonth);
        }

        public IActionResult CustomDateForIncomes(DateTime? startTime, DateTime? endTime)
        {
            List<Income> customIncomes = new List<Income>();

            if (startTime.HasValue && endTime.HasValue)
            {
                customIncomes = _incomeRepository.GetBetweenStartAndEndTime(new Income
                {
                    StartofPeriod = startTime.Value,
                    EndOfPeriod = endTime.Value
                });
            }

            var Model = new CustomIncomeDateViewModel()
            {
                Incomes = customIncomes
            };
            return View(Model);
        }

        public IActionResult GetIncomeDetails(Guid incomeId)
        {
            Income income = _incomeRepository.GetIncomeDetails(incomeId);

            DashboardViewModel model = new DashboardViewModel(income);

            return View("GetIncomeDetails", model);
        }

        public IActionResult GetExpenseDetails (Guid expenseId)
        {
            Expense expense = _expenseRepository.GetExpenseDetails(expenseId);

            DashboardViewModel model = new DashboardViewModel(expense);

            return View("GetExpenseDetails", model);
        }

        public IActionResult UpdateExpenseAmount(DashboardViewModel model)
        {
            _expenseRepository.UpdateExpenseAmount(model.ExpenseId, model.UpdatedExpenseAmount);

            return RedirectToAction("Index");
        }

        public IActionResult UpdateIncomeAmount(DashboardViewModel model)
        {
            _incomeRepository.UpdateIncomeAmount(model.IncomeId, model.UpdatedIncomeAmount);

            return RedirectToAction("Index");
        }

        public IActionResult AddIncomeCategory(Guid IncomeId)
        {
            List<Income> income  = _incomeRepository.GetAllIncomes();

            AddIncomeCategoryViewModel model = new AddIncomeCategoryViewModel()
            {
                AllIncomes = income
            };

        var Category = model.IncomeCategory;

            
        return View(model);
        }

        


    }
}
