namespace Ordering.Application.Orders.Queries.GetOrdersByCustomerName
{
    public record GetOrdersByCustomerQuery(Guid CustomerId) 
        : IQuery<GetOrdersByCustomerResult>;

    public record GetOrdersByCustomerResult(IEnumerable<OrderDto> Orders);
}
