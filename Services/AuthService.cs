using ExpenseTrackerAPI.Constants;
using ExpenseTrackerAPI.Helpers;
using ExpenseTrackerAPI.Interfaces;
using ExpenseTrackerAPI.Models;

namespace ExpenseTrackerAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IExpenseRepository _expenseRepository;
        public AuthService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<BaseResponse> RegisterUser(RegisterUserRq rq)
        {
            var response = new BaseResponse()
            {
                StatusCode = ErrorCodes.ERROR_CODE,
                StatusDescription = ErrorCodes.ERROR_MSG,
                Success = false
            };
            try
            {
                return await _expenseRepository.RegisterUser(rq);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception>> {ex.Message}");
            }

            return response;    

        }

        public async Task<LoginResp> AuthenticateUser(LoginRq rq)
        {

            var result = await _expenseRepository.AuthenticateUser(rq);

            if (result == null)
            {
                return new LoginResp()
                {
                    StatusCode = ErrorCodes.ERROR_CODE,
                    StatusDescription = ErrorCodes.ERROR_MSG,
                    Success = false
                };
            }
            else
            {
                var decryptedPass = HelpingMethods.Base64Decode(result.Password);
                if(rq.Password == decryptedPass)
                {
                    return new LoginResp()
                    {
                        UserId = result.UserId,
                        USerName = $"{result.FirstName} {result.Surname}",
                        StatusCode = ErrorCodes.SUCCESS_CODE,
                        StatusDescription = ErrorCodes.SUCCESS_MSG,
                        Success = true
                    };
                }
            }

            return new LoginResp()
            {
                StatusCode = ErrorCodes.ERROR_CODE,
                StatusDescription = ErrorCodes.ERROR_MSG,
                Success = false
            };

        }
    }
}
