namespace Ordering.Application.Orders.Queries
{
    public record GetOrdersByNameQuery(string name)
        : IQuery<GetOrdersByNameResult>;

    public record GetOrdersByNameResult(IEnumerable<OrderDto> Orders);
}
