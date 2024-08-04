using DeliveryStoreDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeliveryStoreInfra {
    public class DeliveryContext : DbContext {

        public DeliveryContext(DbContextOptions<DeliveryContext> options) : base(options) {
        }


        public DbSet<Product> Product { get; set; }



        protected override void OnModelCreating(ModelBuilder builder) {
            
            builder.Entity<Product>().HasKey(m => m.Id);


            base.OnModelCreating(builder);
        }
    }
}
