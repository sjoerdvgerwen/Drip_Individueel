﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drip.Application.Entities;

namespace Drip.Webapp.Models
{
    public class DashboardViewModel
    {
        public List<Income> AllIncomes = new List<Income>();

        public List<Expense> AllExpenses = new List<Expense>();

        public List<Month> AllMonths = new List<Month>();

        public DashboardViewModel(Income income)
        {
            IncomeId = income.IncomeId;
            Description = income.Description;
            Amount = income.Amount;
            Time = income.TimeOfIncomeCreation;
        }

        public DashboardViewModel(Expense expense)
        {
            ExpenseId = expense.ExpenseId;
            ExpenseDescription = expense.Description;
            ExpenseAmount = expense.Amount;
            TimeOfExpense = expense.TimeOfExpenseCreation; 
        }

        public DashboardViewModel()
        {

        }

        public Guid IncomeId { get; set; }

        public string Description { get; set; }

        public Double Amount { get; set; }

        public DateTime Time { get; set; }

        public Guid ExpenseId { get; set; }

        public string ExpenseDescription { get; set; }

        public Double ExpenseAmount { get; set; }

        public DateTime TimeOfExpense { get; set; }

        public Double UpdatedExpenseAmount { get; set; }

        public Double UpdatedIncomeAmount { get; set; }

        public string IncomeCategory { get; set; }

    }
}