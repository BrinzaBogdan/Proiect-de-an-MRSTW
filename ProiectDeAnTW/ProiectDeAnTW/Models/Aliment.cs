using System.ComponentModel.DataAnnotations;

namespace ProiectDeAnTW.Models
{
	public abstract class Aliment
	{
		[Key]
		public Guid Id { get; set; }
		public string? Name { get; set; }
        public string? Category { get; set; }
        public string? ImageUrl { get; set; }
	}
}
