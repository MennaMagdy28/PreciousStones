using Microsoft.EntityFrameworkCore;
using Diamond.Models;
namespace Diamond.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MOS3AD;Database=PreciousStones;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
/*
 * Name: Menna Magdy Hassan Hassanien
 * University/Dep: Helwan / Software Engineering
 * Level: 4
*/
