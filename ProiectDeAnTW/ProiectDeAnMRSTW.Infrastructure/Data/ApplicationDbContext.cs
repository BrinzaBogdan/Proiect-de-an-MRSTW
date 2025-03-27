using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProiectDeAnMRSTW.Domain.Abstractions;
using ProiectDeAnMRSTW.Domain.Products;
using ProiectDeAnMRSTW.Domain.Reviews;
using ProiectDeAnTW.Data;
using System.ComponentModel.DataAnnotations;

namespace ProiectDeAnMRSTW.Infrastructure.Data
{
    public sealed class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IUnitOfWork
    {
        private readonly IPublisher _publisher;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IPublisher publisher)
            : base(options)
        {
            _publisher = publisher;
        }
        public DbSet<Aliment> Aliment { get; set; }
        public DbSet<CarneSiMezeluri> CarneSiMezeluri { get; set; }
        public DbSet<Dulciuri> Dulciuri { get; set; }
        public DbSet<Peste> Peste { get; set; }
        public DbSet<Fructe> Fructe { get; set; }
        public DbSet<Legume> Legume { get; set; }
        public DbSet<Paste> Paste { get; set; }
        public DbSet<CategorieAliment> CategorieAliment { get; set; }
        public DbSet<Review> Review { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            await PublishDomainEventsAsync();

            return result;
        }

        private async Task PublishDomainEventsAsync()
        {
            var domainEvents = ChangeTracker
                .Entries<Aliment>()
                .Select(entry => entry.Entity)
                .SelectMany(entity =>
                {
                    var domainEvents = entity.GetDomainEvents();

                    entity.ClearDomainEvents();

                    return domainEvents;
                }).ToList();

            foreach(var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
