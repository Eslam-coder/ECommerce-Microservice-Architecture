﻿namespace Ordering.Application.Orders.Queries.GetOrders
{
    public class GetOrdersHandler(IApplicationDbContext dbContext) :
        IQueryHandler<GetOrdersQuery, GetOrdersResult>
    {
        public async Task<GetOrdersResult> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
        {
            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var totalCount = await dbContext.Orders.LongCountAsync();

            var orders = await dbContext.Orders
                                       .Include(order => order.OrderItems)
                                       .OrderBy(order => order.OrderName.Value)
                                       .Skip(pageSize * pageIndex)
                                       .Take(pageSize)
                                       .ToListAsync(cancellationToken);

            return new GetOrdersResult(new PaginatedResult<OrderDto>
            (
                pageIndex, pageSize, totalCount, orders.ToOrderDtoList()
            ));
        }
    }
}
