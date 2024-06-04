namespace JIJI_API.Models
{
    public class ApiResponse<T>
    {
        public int code {  get; set; }
        public string? message { get; set; }
        public Products? Data { get; set; }
    }
}
