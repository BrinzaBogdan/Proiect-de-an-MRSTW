using ProiectDeAnMRSTW.Domain.Reviews;

namespace ProiectDeAnTW.Models
{
    public class ReviewModel
    {
        public string ProductName { get; set; } = "123";
        public Rating Rating { get; set; } = new();
        public Comment Comment { get; set; } = new();
    }
}
