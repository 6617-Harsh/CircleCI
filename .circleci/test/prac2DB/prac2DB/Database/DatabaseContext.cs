using prac2DB.Database.Entity;
using Microsoft.EntityFrameworkCore;
namespace prac2DB.Database
{
    public class DatabaseContext :DbContext
    {
        public DbSet<Users>Users{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Database1;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
        }
    }
}
