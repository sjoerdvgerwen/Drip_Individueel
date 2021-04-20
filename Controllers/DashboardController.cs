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

            var viewModel = new GetAllIncomesViewModel()
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
            
            return RedirectToAction("MonthlyOverview");
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

        public IActionResult CustomDateForIncomes()
        {
            return View();
        }

        public IActionResult GetCustomIncomeTimeStamp(CustomIncomeDateViewModel UserDateInput)
        {
            Income UserInputIncome = new Income()
            {
                StartofPeriod = UserDateInput.StartTime,
                EndOfPeriod = UserDateInput.EndTime
            };

            _incomeRepository.GetUserInputIncomes(UserInputIncome);
            
            return RedirectToAction("CustomIncomesResult", "Dashboard");
        }

        public IActionResult CustomIncomesResult()
        {
            return View();
        }

    }
}
