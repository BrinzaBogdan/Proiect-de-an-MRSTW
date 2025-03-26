using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProiectDeAnMRSTW.Domain.Abstractions;

namespace Bookify.Infrastructure.Configurations;

internal sealed class ProductsConfiguration : IEntityTypeConfiguration<Aliment>
{
    public void Configure(EntityTypeBuilder<Aliment> builder)
    {
        //builder.ToTable("aliments");



        //builder.Property<uint>("Version").IsRowVersion();
    }
}
