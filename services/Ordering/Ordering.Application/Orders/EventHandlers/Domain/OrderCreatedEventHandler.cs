using MassTransit;
using Microsoft.FeatureManagement;

namespace Ordering.Application.Orders.EventHandlers
{
    public class OrderCreatedEventHandler
        (ILogger<OrderCreatedEventHandler> logger, 
         IPublishEndpoint publishEndpoint, 
         IFeatureManager featureManager)
        : INotificationHandler<OrderCreatedEvent>
    {
        public async Task Handle(OrderCreatedEvent domainEvent, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain Event Handled: {DomainEvent}", domainEvent.GetType().Name);
            if(await featureManager.IsEnabledAsync("OrderFulFillment"))
            {
                var orderCreateIntegrationEvent = domainEvent.order.ToOrderDto();
                await publishEndpoint.Publish(orderCreateIntegrationEvent);
            }
        }
    }
}
