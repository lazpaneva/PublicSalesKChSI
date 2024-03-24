using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PublicSalesKChSI.Core.Contracts;
using PublicSalesKChSI.Core.Services;
using PublicSalesKChSI.Infrastructure.Data;
using PublicSalesKChSI.Infrastructure.Data.Common;
using PublicSalesKChSI.Infrastructure.Data.Models;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IHtmlPdfService, HtmlPdfService>();
            services.AddScoped<IBrsFileService, BrsFileService>();
            services.AddScoped<IWorkingOnFilesService, WorkingOnFilesService>();
            services.AddScoped<IGivingWorkService, GivingWorkService>();
            services.AddScoped<IRepository, Repository>();

            return services;
        }
    }
}
