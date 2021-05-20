using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drip.Application.Interfaces;
using Drip.Application.Entities;
using Drip.Webapp.Models;

namespace Drip.Webapp.Controllers
{
    public class ExpenseController : Controller
    {

        public readonly IExpenseRepository _expenseRepository;

        public ExpenseController(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }
        public IActionResult AddNewExpense()
        {
            return View();
        }

        public IActionResult AddExpense(AddNewExpenseViewModel model)
        {
            Expense expense = new Expense()
            {
                ExpenseId = Guid.NewGuid(),
                Amount = model.Amount,
                TimeOfExpenseCreation = DateTime.Now,
                Description = model.Description
            };

            Application.Logic.ExpenseLogic _logic = new Application.Logic.ExpenseLogic();

            if (_logic.IsValueZero(expense.Amount) == true && _logic.IsDescriptionFilledIn(expense.Description) == true)
            {
                _expenseRepository.AddExpense(expense);
            }

            

            return RedirectToAction("Index", "Dashboard");
        }

        public IActionResult UpdateExpenseAmount(DashboardViewModel model)
        
        {
            _expenseRepository.UpdateExpenseAmount(model.ExpenseId, model.UpdatedExpenseAmount);

            return RedirectToAction("Index", "Dashboard");
        }
    }
}
