using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProiectDeAnTW.Models;
using System.ComponentModel.DataAnnotations;

namespace ProiectDeAnTW.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
		public DbSet<Aliment> Aliment { get; set; }
		public DbSet<CarneSiMezeluri> CarneSiMezeluri { get; set; }
		public DbSet<Dulciuri> Dulciuri { get; set; }
		public DbSet<Peste> Peste { get; set; }
		public DbSet<Fructe> Fructe { get; set; }
		public DbSet<Legume> Legume { get; set; }
		public DbSet<Paste> Paste { get; set; }
		public DbSet<CategorieAliment> CategorieAliment { get; set; }


		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//	base.OnModelCreating(modelBuilder);
		//	// Activează TPT (Table-per-Type) pentru clasele moștenite
		//	modelBuilder.Entity<CarneSiMezeluri>().ToTable("CarneSiMezeluri");
		//	modelBuilder.Entity<Dulciuri>().ToTable("Dulciuri");
		//	modelBuilder.Entity<Peste>().ToTable("Peste");
		//	modelBuilder.Entity<Fructe>().ToTable("Fructe");
		//	modelBuilder.Entity<Legume>().ToTable("Legume");
		//	modelBuilder.Entity<Paste>().ToTable("Paste");
		//}

	}
}
