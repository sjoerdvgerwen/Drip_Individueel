using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drip.Application.Interfaces;
using Drip.Application.Entities;
using Drip.Webapp.Models;
using Drip.Application.Logic;
using Drip.Webapp.Models.ExpenseModels;

namespace Drip.Webapp.Controllers
{
    public class ExpenseController : Controller
    {

        private ExpenseLogic _logic;
        private CategoryLogic _CLogic;

        public ExpenseController(ExpenseLogic logic, CategoryLogic Clogic)
        {
            _logic = logic;
            _CLogic = Clogic;
        }

        public IActionResult AddExpense(AddNewExpenseViewModel model)
        {
            bool IsChecked = model.IsChecked;
            DateTime CreationTime = model.CreationTime;

            if (model.Description != null)
            {
                if (model.IsChecked == true && _logic.OnlyCheckBoxIsChecked(IsChecked, CreationTime))
                {
                    Expense expense = new Expense()
                    {
                        ExpenseId = Guid.NewGuid(),
                        Amount = model.Amount,
                        TimeOfExpenseCreation = DateTime.Now,
                        Description = model.Description
                    };
                    model.ExpenseId = expense.ExpenseId;
                    if (_logic.AddExpense(expense))
                    {
                        return RedirectToAction("AddExpenseToCategory", model);
                    }
                    else
                    {
                        return RedirectToAction("Fail");
                    }
                }
            }

            if (model.Description != null)
            {
                if (_logic.OnlyCustomTimeStampIsFilledIn(IsChecked, CreationTime))
                {
                    Expense customTimeExpense = new Expense()
                    {
                        ExpenseId = Guid.NewGuid(),
                        Amount = model.Amount,
                        TimeOfExpenseCreation = model.CreationTime,
                        Description = model.Description
                    };
                    model.ExpenseId = customTimeExpense.ExpenseId;
                    if (_logic.AddExpense(customTimeExpense))
                    {
                        return RedirectToAction("AddExpenseToCategory", model);
                    }
                    else
                    {
                        return RedirectToAction("Fail");
                    }
                }
            }
            return View();
        }

        public IActionResult AddExpenseToCategory(AddNewExpenseViewModel model)
        {
            List<Category> _categories = _CLogic.GetAllCategories();

            model.Categories = _categories;

            if (model.CategoryId != Guid.Empty)
            {
                _CLogic.AddExpenseToCategory(model.CategoryId, model.ExpenseId);
                return RedirectToAction("Succes", model);
            }
            return View(model);
        }

        public IActionResult Succes(AddNewExpenseViewModel model)
        {
            return View(model);
        }






        //}

        //public IActionResult UpdateExpenseAmount(DashboardViewModel model)

        //{
        //    _expenseRepository.UpdateExpenseAmount(model.ExpenseId, model.UpdatedExpenseAmount);

        //    return RedirectToAction("Index", "Dashboard");
        //}
    }
}
