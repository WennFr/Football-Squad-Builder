namespace App.WebAPI.API.Responses
{
    public class ApiResponse<T>
    {
        public string? Id { get; set; }
        public string? Query { get; set; }
        public int PageNumber { get; set; }
        public int LastPageNumber { get; set; }
        public List<T> Results { get; set; } = null!;
        public DateTime UpdatedAt { get; set; }
    }

}
