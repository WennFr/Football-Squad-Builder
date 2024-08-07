namespace App.WebAPI.API.Responses
{
    public class ApiResponse<T>
    {
        public string Query { get; set; } = null!;
        public int PageNumber { get; set; }
        public int LastPageNumber { get; set; }
        public List<T> Results { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
