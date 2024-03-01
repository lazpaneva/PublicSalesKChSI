using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PublicSalesKChSI.Infrastructure.Data.Models;
using PublicSalesKChSI.Infrastructure.Data.Models.FromDownload;
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

            SeedUsers();
            builder.Entity<IdentityUser>()
                .HasData(EmloyeeFirst, EmloyeeSecond);

            base.OnModelCreating(builder);
        }

        //seed AspNetUsers
        private IdentityUser EmloyeeFirst { get; set; } = null!;

        private IdentityUser EmloyeeSecond { get; set; } = null!;

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            EmloyeeFirst = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "ja.iv@abv.bg",
                NormalizedUserName = "JA.IV@ABV.BG",
                Email = "ja.iv@abv.bg",
                NormalizedEmail = "JA.IV@ABV.BG"
            };

            EmloyeeFirst.PasswordHash =
                 hasher.HashPassword(EmloyeeFirst, "jana123");

            EmloyeeSecond = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "ira1970@abv.bg",
                NormalizedUserName = "IRA1970@ABV.BG",
                Email = "ira1970@abv.bg",
                NormalizedEmail = "IRA1970@ABV.BG"
            };

            EmloyeeSecond.PasswordHash =
            hasher.HashPassword(EmloyeeSecond, "ira123");
        }

    }
}