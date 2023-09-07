namespace ExpenseTrackerAPI.Models
{
    public class ViewModel<T> where T : class 
    {
        public BaseResponse Response { get; set; } = null;
        public T Data { get; set; }
        public List<ListCategoryResp> Category { get; set; } = new List<ListCategoryResp>();
    }
}
