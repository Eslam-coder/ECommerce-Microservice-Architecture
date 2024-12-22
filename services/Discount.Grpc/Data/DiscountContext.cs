using Discount.Grpc.Models_Domain_Layer;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
    public class DiscountContext : DbContext
    {
        public DbSet<Coupon> Coupons { get; set; } = default!;

        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().HasData
            ([
                new Coupon { Id = 1, ProductName = "product name1", Description = "desctiption 1", Amount = 10 },
                new Coupon { Id = 2, ProductName = "product name2", Description = "desctiption 2", Amount = 50 }
            ]);
        }
    }
}
