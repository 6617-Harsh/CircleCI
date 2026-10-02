using prac2.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace prac2.Database
{
    public class DatabaseContext:DbContext

    {
        public DbSet<Users> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\ProjectModels;Initial Catalog=Database1;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
                
        }
    }
}
