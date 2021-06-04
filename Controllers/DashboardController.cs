using Drip.Application.Entities;
using Drip.Application.Interfaces;
using Drip.Webapp.Models;
using Drip.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drip.Webapp.Models.DashboardModels;

namespace Drip.Webapp.Controllers
{
    public class DashboardController : Controller
    {
        private Application.Logic.DashboardLogic _logic;

        public DashboardController(Application.Logic.DashboardLogic logic)
        {
            _logic = logic;
        }
        public IActionResult Index()
        {
            DashboardViewModel viewModel = new DashboardViewModel();
            viewModel.AllExpenses = _logic.GetAllExpenses();
            viewModel.AllIncomes = _logic.GetAllIncomes();
            viewModel.ChartResultsPerMonth = _logic.BalancePerMonth();
            viewModel.AllMonths = _logic.GetAllMonths();

            return View(viewModel);
        }

        public IActionResult CustomValues(DateTime? startTime, DateTime? endTime)
        {
            ValuesBetweenTimesViewModel viewModel = new ValuesBetweenTimesViewModel();

            if (startTime.HasValue && endTime.HasValue)
            {
                viewModel.Incomes = _logic.GetIncomeBetweenCustomTimes(new Income
                {
                    StartofPeriod = startTime.Value,
                    EndOfPeriod = endTime.Value
                });

                viewModel.Expenses = _logic.GetExpensesBetweenCustomTimes(new Expense
                {
                    StartOfPeriod = startTime.Value,
                    EndOfPeriod = endTime.Value
                });
            }
            return View(viewModel);
        }
        public IActionResult IncomeDetails(Guid incomeId)
        {
            
            Income income = _logic.GetIncomeDetails(incomeId);

            DashboardViewModel model = new DashboardViewModel(income);

            return View(model);
        }

        public IActionResult ExpenseDetails (Guid expenseId)
        {
            Expense expense = _logic.GetExpenseDetails(expenseId);
                
            DashboardViewModel model = new DashboardViewModel(expense);

            return View(model);
        }

        public IActionResult UpdateExpenseAmount(DashboardViewModel model)
        {
            _logic.UpdateExpenseAmount(model.ExpenseId, model.UpdatedExpenseAmount);

            return RedirectToAction("Index");
        }

        public IActionResult UpdateIncomeAmount(DashboardViewModel model)
        {
            _logic.UpdateIncomeAmount(model.IncomeId, model.UpdatedIncomeAmount); 

            return RedirectToAction("Index");
        }
    }
}
