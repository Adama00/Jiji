using Microsoft.EntityFrameworkCore;

namespace JIJI_API.Models
{
    public class ApiResponseCart<T>
    {
        public string Code { get; set; }
        public string? Message { get; set; }
        public DbSet<Cart> Data { get; set; }
    }
}
