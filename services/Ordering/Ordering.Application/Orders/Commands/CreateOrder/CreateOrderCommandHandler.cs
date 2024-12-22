namespace Ordering.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler(IApplicationDbContext dbContext)
        : ICommandHandler<CreateOrderCommand, CreateOrderCommandResult>
    {
        public async Task<CreateOrderCommandResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            Order newOrder = CreateNewOrder(command.Order);
            dbContext.Orders.Add(newOrder);
            await dbContext.SaveChangesAsync(cancellationToken);
            return new CreateOrderCommandResult(newOrder.Id.Value);
        }

        private Order CreateNewOrder(OrderDto orderDto)
        {
            Address billingAddress = Address.Of
            (
                orderDto.BillingAddress.FirstName,
                orderDto.BillingAddress.LastName,
                orderDto.BillingAddress.EmailAddress,
                orderDto.BillingAddress.AddressLine,
                orderDto.BillingAddress.Country,
                orderDto.BillingAddress.State,
                orderDto.BillingAddress.ZipCode
            );

            Address shippingAddress = Address.Of
            (
                orderDto.ShippingAddress.FirstName,
                orderDto.ShippingAddress.LastName,
                orderDto.ShippingAddress.EmailAddress,
                orderDto.ShippingAddress.AddressLine,
                orderDto.ShippingAddress.Country,
                orderDto.ShippingAddress.State,
                orderDto.ShippingAddress.ZipCode
            );

            Payment payment = Payment.Of
            (
                orderDto.Payment.CardName,
                orderDto.Payment.CardNumber,
                orderDto.Payment.Expiration,
                orderDto.Payment.Cvv,
                orderDto.Payment.PaymentMethod
            );

            Order newOrder = Order.Create
            (
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(orderDto.CustomerId),
                OrderName.Of(orderDto.OrderName),
                shippingAddress,
                billingAddress,
                payment
            );

            foreach (var orderItem in orderDto.OrderItems)
            {
                newOrder.AddOrderItem(ProductId.Of(orderItem.ProductId), orderItem.Quantity, orderItem.Price);
            }

            return newOrder;
        }
    }
}
