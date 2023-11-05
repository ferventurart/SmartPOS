using Bogus;
using Dapper;
using SmartPOS.Products.Application.Abstractions.Data;
using SmartPOS.Products.Domain.Departments;

namespace SmartPOS.Products.Api.Extensions;

public static class SeedDataExtensions
{
    public static void SeedData(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        var sqlConnectionFactory = scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();
        using var connection = sqlConnectionFactory.CreateConnection();

        var faker = new Faker();

        List<object> departments = new();
        for (var i = 0; i < 10; i++)
        {
            departments.Add(new
            {
                Id = Guid.NewGuid(),
                Name = faker.Commerce.Department(),
            });
        }

        const string deparmentsSql = """
            INSERT INTO public.departments
            (id, "name")
            VALUES(@Id, @Name);
            """;

        connection.Execute(deparmentsSql, departments);

        List<object> categories = new();
        foreach (var department in departments)
        {
            categories.Add(new
            {
                Id = Guid.NewGuid(),
                DepartmentId = department.GetType().GetProperty("Id")?.GetValue(department),
                Name = faker.Commerce.Categories(1)[0],
            });
        }


        const string categoriesSql = """
            INSERT INTO public.categories
            (id, "department_id", "name")
            VALUES(@Id, @DepartmentId, @Name);
            """;

        connection.Execute(categoriesSql, categories);
    }
}
