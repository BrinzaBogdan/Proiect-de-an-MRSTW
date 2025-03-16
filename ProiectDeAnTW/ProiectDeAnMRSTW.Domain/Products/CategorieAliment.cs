using System.ComponentModel.DataAnnotations;

namespace ProiectDeAnTW.Models
{
	public class CategorieAliment
	{
		[Key]
		public string? Category { get; set; }
		public string? ImageUrl { get; set; }
		public string? PageLink { get; set; }
	}
}
