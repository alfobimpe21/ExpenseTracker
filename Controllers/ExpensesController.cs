using ExpenseTrackerAPI.Constants;
using ExpenseTrackerAPI.Interfaces;
using ExpenseTrackerAPI.Models;
using ExpenseTrackerAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExpenseTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpensesService _expensesService;
        public ExpensesController(IExpensesService expensesService)
        {
            _expensesService = expensesService;
        }

        [HttpPost("AddCategory")]
        public async Task<BaseResponse> AddCategory([FromBody] AddCategoryRq rq)
        {
            var response = new BaseResponse()
            {
                StatusCode = ErrorCodes.ERROR_CODE,
                StatusDescription = ErrorCodes.ERROR_MSG,
                Success = false
            };

            if (ModelState.IsValid)
            {
                response = await _expensesService.AddCategory(rq);
                return response;
            }

            return response;
        }

        [HttpPost("AddBudget")]
        public async Task<BaseResponse> AddBudget([FromBody] AddBudgetsRq rq)
        {
            var response = new BaseResponse()
            {
                StatusCode = ErrorCodes.ERROR_CODE,
                StatusDescription = ErrorCodes.ERROR_MSG,
                Success = false
            };

            if (ModelState.IsValid)
            {
                response = await _expensesService.AddBudget(rq);
                return response;
            }

            return response;
        }

        [HttpPost("AddExpenses")]
        public async Task<BaseResponse> AddExpenses([FromBody] AddExpensesRq rq)
        {
            var response = new BaseResponse()
            {
                StatusCode = ErrorCodes.ERROR_CODE,
                StatusDescription = ErrorCodes.ERROR_MSG,
                Success = false
            };

            if (ModelState.IsValid)
            {
                response = await _expensesService.AddExpenses(rq);
                return response;
            }

            return response;
        }

        [HttpPost("ListCategory")]
        public async Task<List<ListCategoryResp>> ListCategory([FromBody] ListRequest rq)
        {
            var response = await _expensesService.ListCategory(rq.UserId);
            return response;
        }        

        [HttpPost("ListBudget")]
        public async Task<List<ListBudgetResp>> ListBudget([FromBody] ListRequest rq)
        {
            var response = await _expensesService.ListBudget(rq.UserId);
            return response;
        }

        [HttpPost("ListExpenses")]
        public async Task<List<ListExpensesResp>> ListExpenses([FromBody] ListRequest rq)
        {
            var response = await _expensesService.ListExpenses(rq.UserId);
            return response;
        }

        [HttpPost("DeleteCategory")]
        public async Task<BaseResponse> DeleteCategory([FromBody] DeleteRq rq)
        {
            var response = await _expensesService.DeleteCategory(rq);
            return response;
        }

        [HttpPost("DeleteBudget")]
        public async Task<BaseResponse> DeleteBudget([FromBody] DeleteRq rq)
        {
            var response = await _expensesService.DeleteBudget(rq);
            return response;
        }

        [HttpPost("DeleteExpenses")]
        public async Task<BaseResponse> DeleteExpenses([FromBody] DeleteRq rq)
        {
            var response = await _expensesService.DeleteExpenses(rq);
            return response;
        }

    }
}
