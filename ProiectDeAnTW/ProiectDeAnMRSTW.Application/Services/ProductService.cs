using Microsoft.EntityFrameworkCore;
using ProiectDeAnTW.Models;

namespace ProiectDeAnTW.Data.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddProduct(Aliment aliment)
        {
            _context.Aliment.Add(aliment);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Aliment>> GetAllProducts()
        {
            return await _context.Aliment.ToListAsync();
        }
        public async Task<List<Aliment>> GetCarne()
        {
            return await _context.Aliment.Where(x => x.Category == "Carne").ToListAsync();
        }
        public async Task<List<Aliment>> GetPaste()
        {
            return await _context.Aliment.Where(x => x.Category == "Paste").ToListAsync();
        }
        public async Task<List<Aliment>> GetPeste()
        {
            return await _context.Aliment.Where(x => x.Category == "Peste").ToListAsync();
        }
        public async Task<List<Aliment>> GetDulciuri()
        {
            return await _context.Aliment.Where(x => x.Category == "Dulciuri").ToListAsync();
        }
        public async Task<List<Aliment>> GetFructe()
        {
            return await _context.Aliment.Where(x => x.Category == "Fructe").ToListAsync();
        }
        public async Task<List<Aliment>> GetLegume()
        {
            return await _context.Aliment.Where(x => x.Category == "Legume").ToListAsync();
        }
        public async Task DeleteProductByName(string name)
        {
            var aliment = await _context.Aliment.FirstOrDefaultAsync(x => x.Name == name);

            if (aliment != null)
            {
                _context.Aliment.Remove(aliment);
                await _context.SaveChangesAsync(); // Aplică modificările în baza de date
            }
        }
    }
}
