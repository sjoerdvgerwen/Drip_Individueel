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
        private Drip.Application.Logic.DashboardLogic _logic;

        public DashboardController(Drip.Application.Logic.DashboardLogic logic)
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
            Income income = _incomeRepository.GetIncomeDetails(incomeId);
            _logic.Get

            DashboardViewModel model = new DashboardViewModel(income);

            return View("GetIncomeDetails", model);
        }

        //public IActionResult GetExpenseDetails (Guid expenseId)
        //{
        //    Expense expense = _expenseRepository.GetExpenseDetails(expenseId);

        //    DashboardViewModel model = new DashboardViewModel(expense);

        //    return View("GetExpenseDetails", model);
        //}

        //public IActionResult UpdateExpenseAmount(DashboardViewModel model)
        //{
        //    _expenseRepository.UpdateExpenseAmount(model.ExpenseId, model.UpdatedExpenseAmount);

        //    return RedirectToAction("Index");
        //}

        //public IActionResult UpdateIncomeAmount(DashboardViewModel model)
        //{
        //    _incomeRepository.UpdateIncomeAmount(model.IncomeId, model.UpdatedIncomeAmount);

        //    return RedirectToAction("Index");
        //}

        //public IActionResult Chart()
        //{
        //    List<Month> months =_dashboardRepository.GetAllMonths();

        //    List<Income> incomeData = _dashboardRepository.GetChartIncomeData(months);

        //    List<Expense> expenseData = _dashboardRepository.GetChartExpenseData(months);

        //    ChartViewModel model = new ChartViewModel();

        //    model.IncomesPerMonth = incomeData;
        //    model.ExpensesPerMonth = expenseData;

        //    List<Double> resultPerMonth = new List<Double>();

        //    for (int i = 0; i < incomeData.Count;)
        //    {
        //        for (int j = 0; j < expenseData.Count;)
        //        {
        //            Double Results = incomeData[i].Amount - expenseData[i].Amount;
        //            resultPerMonth.Add(Results);
        //            i++;
        //            j++;
        //        }
        //    }

        //    model.Result = resultPerMonth;

        //    return View(model);
        //}
    }
}
