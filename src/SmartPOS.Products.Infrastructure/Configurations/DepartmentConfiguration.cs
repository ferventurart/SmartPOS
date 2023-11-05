using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartPOS.Products.Domain.Departments;

namespace SmartPOS.Products.Infrastructure.Configurations;

internal sealed class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("departments");

        builder.HasKey(department => department.Id);

        builder.Property(department => department.Id)
            .HasConversion(department => department.Value, value => new DepartmentId(value));

        builder.HasIndex(department => department.Name);

        builder.Property(department => department.Name)
               .HasMaxLength(60)
               .HasConversion(department => department.Value, value => new Name(value));
    }
}
