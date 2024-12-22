namespace Ordering.Infrastructure.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(product => product.Id)
                   .IsRequired();
            builder.Property(product => product.Id)
                   .HasConversion(productId => productId.Value,
                                  dbId => ProductId.Of(dbId));
            builder.Property(product => product.Name)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}
