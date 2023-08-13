namespace ExpenseTrackerAPI.Models
{
    public class LoginResp : BaseResponse
    {
        public string UserId { get; set; } = null;
        public string USerName { get; set; } = null;
    }
}
