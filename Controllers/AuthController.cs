using ExpenseTrackerAPI.Constants;
using ExpenseTrackerAPI.Interfaces;
using ExpenseTrackerAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExpenseTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("RegisterUser")]
        public async Task<BaseResponse> ResgisterUser([FromBody] RegisterUserRq rq)
        {
            var response = new BaseResponse()
            {
                StatusCode = ErrorCodes.ERROR_CODE,
                StatusDescription = ErrorCodes.ERROR_MSG,
                Success = false
            };

            if(ModelState.IsValid)
            {
                response =  await _authService.RegisterUser(rq);
                return response;
            }

            return response;
        }

        [HttpPost("ValidateUser")]
        public async Task<LoginResp> ValidateUser([FromBody] LoginRq rq)
        {
            var response = new LoginResp()
            {
                StatusCode = ErrorCodes.ERROR_CODE,
                StatusDescription = ErrorCodes.ERROR_MSG,
                Success = false
            };

            if (ModelState.IsValid)
            {
                response = await _authService.AuthenticateUser(rq);
                return response;
            }

            return response;
        }
    }
}
