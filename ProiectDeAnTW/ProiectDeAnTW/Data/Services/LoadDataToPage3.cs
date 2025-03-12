using Microsoft.EntityFrameworkCore;
using ProiectDeAnTW.Models;

namespace ProiectDeAnTW.Data.Services
{
	public class LoadDataToPage3
	{
		private readonly ApplicationDbContext _context;

		public LoadDataToPage3(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<CategorieAliment>> GetAllCategories()
		{
            try
            {
                return await _context.CategorieAliment.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching categories: {ex.Message}");
                return new List<CategorieAliment>(); // returnează o listă goală în caz de eroare
            }
        }
	}
}
