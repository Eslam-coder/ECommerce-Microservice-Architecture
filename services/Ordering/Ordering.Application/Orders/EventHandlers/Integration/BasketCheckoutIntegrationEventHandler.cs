using BuildingBlocks.Messaging.Events;
using MassTransit;
using Ordering.Application.Orders.Commands.CreateOrder;

namespace Ordering.Application.Orders.EventHandlers.Integration
{
    public class BasketCheckoutIntegrationEventHandler
        (ILogger<BasketCheckoutIntegrationEventHandler> logger, ISender sender)
        : IConsumer<BasketCheckoutEvent>
    {
        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            logger.LogInformation("Integration Event Handled: {IntegrationEvent}", context.Message);
            var command = MapToCreateOrderCommand(context.Message);
            await sender.Send(command);   
        }

        private CreateOrderCommand MapToCreateOrderCommand(BasketCheckoutEvent message)
        {
            AddressDto addressDto = new AddressDto
            (
                message.FirstName,
                message.LastName,
                message.EmailAddress,
                message.AddressLine,
                message.Country,
                message.State,
                message.ZipCode
            );

            PaymentDto paymentDto = new PaymentDto
            (
                message.CardName,
                message.CardNumber,
                message.Expiration,
                message.CVV,
                message.PaymentMethod
            );
            var orderId = Guid.NewGuid();

            OrderDto orderDto = new OrderDto
            (
                Id: Guid.NewGuid(),
                CustomerId: message.CustomerId,
                OrderName: message.UserName,
                ShippingAddress: addressDto,
                BillingAddress: addressDto,
                Payment: paymentDto,
                Status: Domain.Enums.OrderStatus.Pending,
                OrderItems: 
                           [
                               new OrderItemDto(orderId, new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61"), 1, 15),
                               new OrderItemDto(orderId, new Guid("c67d6323-e8b1-4bdf-9a75-b0d8d2e7e914"), 1, 35)
                           ]
            );
            return new CreateOrderCommand(orderDto);
        }
    }
}
