using ExpenseTrackerAPI.Models;

namespace ExpenseTrackerAPI.Interfaces
{
    public interface IAuthService
    {
        Task<BaseResponse> RegisterUser(RegisterUserRq rq);
        Task<LoginResp> AuthenticateUser(LoginRq rq);
    }
}
