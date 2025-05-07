using System.ComponentModel.DataAnnotations;

namespace ProiectDeAnMRSTW.Domain.Products
{
    public class CategorieAliment
    {
        [Key]
        public string? Category { get; set; }
        public string? ImageUrl { get; set; }
        public string? PageLink { get; set; }
    }
}
