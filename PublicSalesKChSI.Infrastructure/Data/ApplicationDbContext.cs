using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PublicSalesKChSI.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //      modelBuilder.Entity<BrsFIle>()
        //.HasOne(e => e.Employee)
        //.WithMany(d => d.BrsFIle)
        //.HasForeignKey(e => e.EmployeeId);

    }
}