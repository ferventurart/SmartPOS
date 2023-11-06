using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartPOS.Products.Domain.Products;
using SmartPOS.Products.Domain.Shared;
using SmartPOS.Products.Domain.Taxes;

namespace SmartPOS.Products.Infrastructure.Configurations;

internal sealed class TaxConfiguration : IEntityTypeConfiguration<Tax>
{
    public void Configure(EntityTypeBuilder<Tax> builder)
    {
        builder.ToTable("taxes");

        builder.HasKey(tax => tax.Id);

        builder.Property(tax => tax.Id)
            .HasConversion(tax => tax.Value, value => new TaxId(value));

        builder.HasIndex(tax => tax.Name);

        builder.Property(tax => tax.Name)
               .HasMaxLength(10)
               .HasConversion(tax => tax.Value, value => new Domain.Taxes.Name(value));

        builder.Property(tax => tax.Percentage)
               .HasConversion(tax => tax.Value, value => Percentage.FromValue(value));
    }
}
