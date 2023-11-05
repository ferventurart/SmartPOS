using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartPOS.Products.Domain.Categories;
using SmartPOS.Products.Domain.Departments;

namespace SmartPOS.Products.Infrastructure.Configurations;

internal sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("categories");

        builder.HasKey(category => category.Id);

        builder.Property(category => category.Id)
            .HasConversion(category => category.Value, value => new CategoryId(value));

        builder.HasIndex(category => category.Name);

        builder.Property(category => category.Name)
               .HasMaxLength(60)
               .HasConversion(category => category.Value, value => new Domain.Categories.Name(value));

        builder.HasOne<Department>()
               .WithMany()
               .HasForeignKey(category => category.DepartmentId);
    }
}
