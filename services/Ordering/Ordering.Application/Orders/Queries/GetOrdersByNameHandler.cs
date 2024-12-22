namespace Ordering.Application.Orders.Queries
{
    public class GetOrdersByNameHandler(IApplicationDbContext dbContext) :
        IQueryHandler<GetOrdersByNameQuery, GetOrdersByNameResult>
    {
        public async Task<GetOrdersByNameResult> Handle(GetOrdersByNameQuery query, CancellationToken cancellationToken)
        {
           var orders = await dbContext.Orders
                                       .Include(order => order.OrderItems)
                                       .AsNoTracking()
                                       .Where(order => order.OrderName.Value.Contains(query.name))
                                       .OrderBy(order => order.OrderName.Value)
                                       .ToListAsync();

            return new GetOrdersByNameResult(orders.ToOrderDtoList());
        }
    }
}
