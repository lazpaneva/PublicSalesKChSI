namespace PublicSalesKChSI.Infrastructure.Data.SeedDb
{
    public interface ISeeder
    {
        Task SeedAsync(PublicSalesDbContext context, IServiceProvider serviceProvider);
    }
}
