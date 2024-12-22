namespace Ordering.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler(IApplicationDbContext dbContext) :
        ICommandHandler<UpdateOrderCommand, UpdateOrderCommandResult>
    {
        public async Task<UpdateOrderCommandResult> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            OrderId orderId = OrderId.Of(command.order.Id);
            var existingOrder = await dbContext.Orders
                                               .FindAsync([orderId], cancellationToken:cancellationToken);
            if(existingOrder is null)
            {
                throw new OrderNotFoundException(command.order.Id);
            }
            UpdateOrderWithNewValues(existingOrder, command.order);

            dbContext.Orders.Update(existingOrder);
            await dbContext.SaveChangesAsync(cancellationToken);
            return new UpdateOrderCommandResult(true);
        }

        private void UpdateOrderWithNewValues(Order existingOrder, OrderDto order)
        {
            Address shippingAddress = Address.Of
            (
                order.ShippingAddress.FirstName,
                order.ShippingAddress.LastName,
                order.ShippingAddress.EmailAddress,
                order.ShippingAddress.AddressLine,
                order.ShippingAddress.Country,
                order.ShippingAddress.State,
                order.ShippingAddress.ZipCode
            );

            Address billingAddress = Address.Of
            (
                order.BillingAddress.FirstName,
                order.BillingAddress.LastName,
                order.BillingAddress.EmailAddress,
                order.BillingAddress.AddressLine,
                order.BillingAddress.Country,
                order.BillingAddress.State,
                order.BillingAddress.ZipCode
            );

            Payment payment = Payment.Of
            (
                order.Payment.CardName,
                order.Payment.CardNumber,
                order.Payment.Expiration,
                order.Payment.Cvv,
                order.Payment.PaymentMethod
            );

            existingOrder.Update
            (
                OrderName.Of(order.OrderName),
                shippingAddress,
                billingAddress,
                payment,
                order.Status
            );
        }
    }
}
