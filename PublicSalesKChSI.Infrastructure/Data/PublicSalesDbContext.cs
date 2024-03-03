using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PublicSalesKChSI.Infrastructure.Data.Models;
using PublicSalesKChSI.Infrastructure.Data.Models.FromDownload;
using PublicSalesKChSI.Infrastructure.Data.SeedDb;
using System.Reflection.Emit;

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

        public DbSet<LastDownNumber> LastDownNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TempHtml>()
                    .HasOne(f => f.BrsFile)
                    .WithMany(h=>h.HtmlFiles)
                    .HasForeignKey(f => f.BrsFileId)
                    .OnDelete(DeleteBehavior.Restrict);

                     builder.ApplyConfiguration(new UserConfiguration());
                     builder.ApplyConfiguration(new LastDownNumberConfiguration());
                     builder.ApplyConfiguration(new CourtConfiguration());
                
            base.OnModelCreating(builder);
        }
    }
}