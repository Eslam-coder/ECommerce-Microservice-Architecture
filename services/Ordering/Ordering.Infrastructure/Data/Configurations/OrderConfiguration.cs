namespace Ordering.Infrastructure.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(order => order.Id);

            builder.Property(order => order.Id)
                   .HasConversion(orderId => orderId.Value,
                                  dbId => OrderId.Of(dbId));

            builder.HasOne<Customer>()
                   .WithMany()
                   .HasForeignKey(order => order.CustomerId)
                   .IsRequired();

            builder.HasMany<OrderItem>()
                   .WithOne()
                   .HasForeignKey(order => order.OrderId);

            builder.ComplexProperty(order => order.OrderName,
                                    nameBuilder =>
                                    {
                                        nameBuilder.Property(order => order.Value)
                                                   .HasColumnName(nameof(Order.OrderName))
                                                   .HasMaxLength(100)
                                                   .IsRequired();
                                    });

            builder.ComplexProperty(order => order.ShippingAddress, shippingAddressBuilder =>
                                    {
                                        shippingAddressBuilder.Property(address => address.FirstName)
                                                              .HasMaxLength(50)
                                                              .IsRequired();

                                        shippingAddressBuilder.Property(address => address.LastName)
                                                              .HasMaxLength(50)
                                                              .IsRequired();

                                        shippingAddressBuilder.Property(address => address.EmailAddress)
                                                              .HasMaxLength(50);

                                        shippingAddressBuilder.Property(address => address.AddressLine)
                                                              .HasMaxLength(180)
                                                              .IsRequired();

                                        shippingAddressBuilder.Property(address => address.Country)
                                                              .HasMaxLength(50);

                                        shippingAddressBuilder.Property(address => address.State)
                                                              .HasMaxLength(50);

                                        shippingAddressBuilder.Property(address => address.ZipCode)
                                                              .HasMaxLength(5)
                                                              .IsRequired();
                                    });

            builder.ComplexProperty(order => order.BillingAddress, billingAddressBuilder =>
                                    {
                                        billingAddressBuilder.Property(address => address.FirstName)
                                                             .HasMaxLength(50)
                                                             .IsRequired();

                                        billingAddressBuilder.Property(address => address.LastName)
                                                              .HasMaxLength(50)
                                                              .IsRequired();

                                        billingAddressBuilder.Property(address => address.EmailAddress)
                                                              .HasMaxLength(50);

                                        billingAddressBuilder.Property(address => address.AddressLine)
                                                              .HasMaxLength(180)
                                                              .IsRequired();

                                        billingAddressBuilder.Property(address => address.Country)
                                                              .HasMaxLength(50);

                                        billingAddressBuilder.Property(address => address.State)
                                                              .HasMaxLength(50);

                                        billingAddressBuilder.Property(address => address.ZipCode)
                                                             .HasMaxLength(5)
                                                             .IsRequired();
                                    });

            builder.ComplexProperty(order => order.Payment, paymentBuilder =>
                                    {
                                        paymentBuilder.Property(payment => payment.CardName)
                                                      .HasMaxLength(50);
                                    
                                        paymentBuilder.Property(payment => payment.CardNumber)
                                                      .HasMaxLength(24)
                                                      .IsRequired();
                                    
                                        paymentBuilder.Property(payment => payment.Expiration)
                                                      .HasMaxLength(10);
                                    
                                        paymentBuilder.Property(payment => payment.CVV)
                                                      .HasMaxLength(3);
                                    
                                        paymentBuilder.Property(payment => payment.PaymentMethod);
                                    });

            builder.Property(order => order.Status)
                   .HasDefaultValue(OrderStatus.Draft)
                   .HasConversion(orderStatus => orderStatus.ToString(),
                                  dbStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), dbStatus));

            builder.Property(order => order.TotalPrice);
        }
    }
}
