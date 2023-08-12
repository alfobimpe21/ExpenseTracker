namespace ExpenseTrackerAPI.Models
{
    public class BaseResponse
    {
        public string StatusCode { get; set; }
        public bool Success { get; set; }
        public string StatusDescription { get; set; }
    }
}
