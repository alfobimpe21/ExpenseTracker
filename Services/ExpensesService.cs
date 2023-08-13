using ExpenseTrackerAPI.Constants;
using ExpenseTrackerAPI.Interfaces;
using ExpenseTrackerAPI.Models;

namespace ExpenseTrackerAPI.Services
{
    public class ExpensesService : IExpensesService
    {
        private readonly IExpenseRepository _expenseRepository;
        public ExpensesService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<BaseResponse> AddCategory(AddCategoryRq rq)
        {
            var response = new BaseResponse()
            {
                StatusCode = ErrorCodes.ERROR_CODE,
                StatusDescription = ErrorCodes.ERROR_MSG,
                Success = false
            };
            try
            {
                return await _expenseRepository.AddCategory(rq);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception>> {ex.Message}");
            }

            return response;

        }

        public async Task<BaseResponse> AddBudget(AddBudgetsRq rq)
        {
            var response = new BaseResponse()
            {
                StatusCode = ErrorCodes.ERROR_CODE,
                StatusDescription = ErrorCodes.ERROR_MSG,
                Success = false
            };
            try
            {
                return await _expenseRepository.AddBudget(rq);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception>> {ex.Message}");
            }

            return response;

        }

        public async Task<BaseResponse> AddExpenses(AddExpensesRq rq)
        {
            var response = new BaseResponse()
            {
                StatusCode = ErrorCodes.ERROR_CODE,
                StatusDescription = ErrorCodes.ERROR_MSG,
                Success = false
            };
            try
            {
                return await _expenseRepository.AddExpenses(rq);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception>> {ex.Message}");
            }

            return response;

        }
    }
}