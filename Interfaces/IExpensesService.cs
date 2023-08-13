using ExpenseTrackerAPI.Models;

namespace ExpenseTrackerAPI.Interfaces
{
    public interface IExpensesService
    {
        Task<BaseResponse> AddCategory(AddCategoryRq rq);
        Task<BaseResponse> AddBudget(AddBudgetsRq rq);
        Task<BaseResponse> AddExpenses(AddExpensesRq rq);
    }
}
