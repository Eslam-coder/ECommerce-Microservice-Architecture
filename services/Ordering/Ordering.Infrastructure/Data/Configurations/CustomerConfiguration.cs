﻿namespace Ordering.Infrastructure.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(customer => customer.Id);
            builder.Property(customer => customer.Id)
                   .HasConversion(customerId => customerId.Value, 
                                  dbId => CustomerId.Of(dbId));
            builder.Property(customer => customer.Name)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(customer => customer.Name)
                   .HasMaxLength(255);
            builder.HasIndex(customer => customer.Email)
                   .IsUnique();
        }
    }
}
