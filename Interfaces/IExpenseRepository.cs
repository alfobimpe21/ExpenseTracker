using ExpenseTrackerAPI.Models;

namespace ExpenseTrackerAPI.Interfaces
{
    public interface IExpenseRepository
    {
        Task<BaseResponse> AddCategory(AddCategoryRq request);
        Task<BaseResponse> AddBudget(AddBudgetsRq request);
        Task<BaseResponse> AddExpenses(AddExpensesRq request);
        Task<BaseResponse> RegisterUser(RegisterUserRq request);
        Task<UserDetailsResp> AuthenticateUser(LoginRq request);
        Task<List<ListCategoryResp>> ListCategory(string UserId);
        Task<List<ListBudgetResp>> ListBudget(string UserId);
        Task<List<ListExpensesResp>> ListExpenses(string UserId);
    }
}
