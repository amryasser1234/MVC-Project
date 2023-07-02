using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectOwn.Models;

namespace ProjectOwn.Date
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base (options)
        {

        }
        public DbSet<Items> Items { get; set; }  
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee>  Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
             new Category { Id = 1, Name = "Select Category" }, 
             new Category { Id = 2, Name = "Computers" },
             new Category { Id = 3, Name = "Mobiles" },
             new Category { Id = 4, Name = "Electric Machines" }          
             );

            var userId = Guid.NewGuid().ToString();
            var RoleAdminId = Guid.NewGuid().ToString();


            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    NormalizedName = "admin",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                },
                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User",
                    NormalizedName = "user",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });

            base.OnModelCreating(modelBuilder);
        }

    }
}
