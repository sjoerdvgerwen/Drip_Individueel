using System;
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

        public List<Income> MonthIncomes = new List<Income>();

        public List<Expense> MonthExpenses = new List<Expense>();

        public List<Expense> ExpensesPerMonth = new List<Expense>();

        public List<double> ChartResultsPerMonth = new List<double>();
        public List<Income> IncomesPerMonth { get; set; }

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
        public string ExpenseDescription { get; set; }

        public double ExpenseAmount { get; set; }

        public Guid IncomeId { get; set; }

        public string Description { get; set; }

        public Double Amount { get; set; }

        public DateTime Time { get; set; }

        public Guid ExpenseId { get; set; }

        public DateTime TimeOfExpense { get; set; }

        public Double UpdatedExpenseAmount { get; set; }

        public Double UpdatedIncomeAmount { get; set; }
    }
}
