using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PublicSalesKChSI.Infrastructure.Data.Models;
using PublicSalesKChSI.Infrastructure.Data.Models.FromDownload;

namespace PublicSalesKChSI.Infrastructure.Data
{
    public class PublicSalesDbContext : IdentityDbContext
    {
        public PublicSalesDbContext(DbContextOptions<PublicSalesDbContext> options)
            : base(options)
        {
        }

        public DbSet<BrsFile> BrsFiles { get; set; }

        public DbSet<TempHtml> TempHtmls { get; set; }

        public DbSet<TempPdf> TempPdfs { get; set; }

        public DbSet<HtmlSeekAttrib> HtmlSeekAttribs { get; set; }

        public DbSet<Court> Courts { get; set; }

        public DbSet<DeptorOld> DeptorOlds { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
              base.OnModelCreating(builder);
        }

 

    }
}