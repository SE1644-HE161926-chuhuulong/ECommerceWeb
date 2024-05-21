
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProjectAPI.Models
{
   public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
   {
      public ApplicationDbContext()
      {
      }
      public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
      {
      }
      public virtual DbSet<Product> Products { get; set; }
      public virtual DbSet<Category> Categories { get; set; }

      public virtual DbSet<Order> Orders { get; set; }

      public virtual DbSet<OrderDetail> OrderDetails { get; set; }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         if (!optionsBuilder.IsConfigured)
         {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string connectionString = config.GetConnectionString("SqlConnection");
            optionsBuilder.UseSqlServer(connectionString);
         }

      }
      protected void OnModelCreating(ModelBuilder modelBuilder)
      {

      }
   }
}
