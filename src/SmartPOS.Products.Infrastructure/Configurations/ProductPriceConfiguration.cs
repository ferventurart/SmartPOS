using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartPOS.Products.Domain.Prices;
using SmartPOS.Products.Domain.Products;
using SmartPOS.Products.Domain.Shared;

namespace SmartPOS.Products.Infrastructure.Configurations;

internal sealed class ProductPriceConfiguration : IEntityTypeConfiguration<ProductPrice>
{
    public void Configure(EntityTypeBuilder<ProductPrice> builder)
    {
        builder.ToTable("product_prices");

        builder.HasKey(product => product.Id);

        builder.Property(product => product.Id)
               .HasConversion(product => product.Value, value => new ProductPriceId(value));

        builder.OwnsOne(product => product.Price, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
                        .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });

        builder.OwnsOne(product => product.PriceWithTax, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
                        .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });

        builder.Property(product => product.Utility)
               .HasConversion(tax => tax.Value, value => Percentage.FromValue(value));

        builder.Property(product => product.PriceStartingFrom)
               .IsRequired(false);

        builder.HasOne<Product>()
               .WithMany()
               .HasForeignKey(product => product.ProductId);
    }
}
