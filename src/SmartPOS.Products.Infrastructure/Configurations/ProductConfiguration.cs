using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartPOS.Products.Domain.Categories;
using SmartPOS.Products.Domain.Products;
using SmartPOS.Products.Domain.Shared;
using SmartPOS.Products.Domain.Taxes;

namespace SmartPOS.Products.Infrastructure.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");

        builder.HasKey(product => product.Id);

        builder.Property(product => product.Id)
               .HasConversion(product => product.Value, value => new ProductId(value));

        builder.Property(product => product.Barcode)
               .HasMaxLength(150)
               .HasConversion(product => product.Value, value => new Barcode(value));

        builder.HasIndex(product => product.Barcode);

        builder.Property(product => product.Sku)
               .HasConversion(product => product.Value, value => Sku.Create(value));

        builder.HasIndex(product => product.Sku);

        builder.Property(category => category.Name)
               .HasMaxLength(75)
               .HasConversion(category => category.Value, value => new Domain.Products.Name(value));

        builder.Property(product => product.Description)
               .HasMaxLength(300);

        builder.OwnsOne(product => product.Cost, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });

        builder.OwnsOne(product => product.CostWithTaxes, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });

        builder.HasOne<Category>()
               .WithMany()
               .HasForeignKey(product => product.CategoryId);

        builder.HasMany(e => e.Taxes)
               .WithMany(e => e.Products)
               .UsingEntity<ProductTax>(
                    l => l.HasOne<Tax>().WithMany().HasForeignKey(e => e.TaxId),
                    r => r.HasOne<Product>().WithMany().HasForeignKey(e => e.ProductId));
    }
}
