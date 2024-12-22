using Ordering.Domain.Models;

namespace Ordering.Application.Extensions
{
    public static class OrderExtensions
    {
        public static IEnumerable<OrderDto> ToOrderDtoList(this List<Order> orders)
        {
            return orders.Select(order => new OrderDto
            (
                Id: order.Id.Value,
                CustomerId: order.CustomerId.Value,
                OrderName: order.OrderName.Value,
                ShippingAddress: MapToAddressDto(order.ShippingAddress),
                BillingAddress: MapToAddressDto(order.BillingAddress),
                Payment: MapToPaymentDto(order.Payment),
                Status: order.Status,
                OrderItems: order.OrderItems.Select(MapToOrderItemDto).ToList()
            ));
        }

        public static OrderDto ToOrderDto(this Order order)
        {
            return DtoFromOrder(order);
        }

        private static OrderDto DtoFromOrder(Order order)
        {
            return new OrderDto
            (
                Id: order.Id.Value,
                CustomerId: order.CustomerId.Value,
                OrderName: order.OrderName.Value,
                ShippingAddress: MapToAddressDto(order.ShippingAddress),
                BillingAddress: MapToAddressDto(order.BillingAddress),
                Payment: MapToPaymentDto(order.Payment),
                Status: order.Status,
                OrderItems: order.OrderItems.Select(MapToOrderItemDto).ToList()
            );
        }

        private static AddressDto MapToAddressDto(Address address)
        {
            return new AddressDto
            (
                address.FirstName,
                address.LastName,
                address.EmailAddress!,
                address.AddressLine,
                address.Country,
                address.State,
                address.ZipCode
           );
        }

        private static PaymentDto MapToPaymentDto(Payment payment)
        {
            return new PaymentDto
            (
                CardName: payment.CardName!,
                CardNumber: payment.CardNumber,
                Expiration: payment.Expiration,
                Cvv: payment.CVV,
                PaymentMethod: payment.PaymentMethod
            );
        }

        private static OrderItemDto MapToOrderItemDto(OrderItem orderItem)
        {
            return new OrderItemDto
            (
                 OrderId: orderItem.OrderId.Value,
                 ProductId: orderItem.ProductId.Value,
                 Quantity: orderItem.Quantity,
                 Price: orderItem.Price
            );
        }
    }
}
