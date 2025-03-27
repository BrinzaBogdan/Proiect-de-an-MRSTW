using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProiectDeAnMRSTW.Domain.Abstractions;
using ProiectDeAnMRSTW.Domain.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDeAnMRSTW.Infrastructure.Configurations
{
    internal sealed class ReviewsConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> entity)
        {
            entity.ToTable("reviews");
            entity.HasKey(e => e.Id);

             entity.Property(e => e.ProductId)
                  .IsRequired();

            entity.Property(e => e.CreatedOnUtc)
                 .HasDefaultValueSql("GETUTCDATE()")
                  .IsRequired();

            entity.OwnsOne(e => e.Comment, cb =>
            {
                cb.Property(c => c.Value)
                  .HasColumnName("Comment")
                  .IsRequired();
            });

            entity.OwnsOne(e => e.Rating, rb =>
            {
                rb.Property(r => r.Value)
                  .HasColumnName("Rating")
                  .IsRequired();
            });
        }
    }
}
