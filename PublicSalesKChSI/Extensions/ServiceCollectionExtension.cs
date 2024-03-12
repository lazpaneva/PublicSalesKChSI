using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PublicSalesKChSI.Core.Contracts;
using PublicSalesKChSI.Core.Services;
using PublicSalesKChSI.Infrastructure.Data;
using PublicSalesKChSI.Infrastructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IHtmlPdfService, HtmlPdfService>();
            services.AddScoped<IBrsFileService, BrsFileService>();

            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<PublicSalesDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IRepository, Repository>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                })
    .AddEntityFrameworkStores<PublicSalesDbContext>();

            return services;
        }

    }
}
