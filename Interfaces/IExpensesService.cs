using ExpenseTrackerAPI.Models;

namespace ExpenseTrackerAPI.Interfaces
{
    public interface IExpensesService
    {
        Task<BaseResponse> AddCategory(AddCategoryRq rq);
        Task<BaseResponse> AddBudget(AddBudgetsRq rq);
        Task<BaseResponse> AddExpenses(AddExpensesRq rq);

        Task<List<ListCategoryResp>> ListCategory(string UserId);

        Task<List<ListBudgetResp>> ListBudget(string UserId);
        Task<List<ListExpensesResp>> ListExpenses(string UserId);

        Task<BaseResponse> DeleteCategory(DeleteRq req);
        Task<BaseResponse> DeleteExpenses(DeleteRq req);
        Task<BaseResponse> DeleteBudget(DeleteRq req);
        Task<Statistics> Statistics();
    }
}
