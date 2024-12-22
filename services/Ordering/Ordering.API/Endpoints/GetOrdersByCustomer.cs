﻿using Ordering.Application.Orders.Queries.GetOrdersByCustomerName;

namespace Ordering.API.Endpoints
{
    public record GetOrdersByCustomerResponse(IEnumerable<OrderDto> Orders);

    public class GetOrdersByCustomer : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/order/{customerId}", async (Guid CustomerId, ISender sender) =>
            {
                var result = await sender.Send(new GetOrdersByCustomerQuery(CustomerId));
                var response = result.Adapt<GetOrdersByCustomerResponse>();
                return Results.Ok(response);
            })
            .WithName("GetOrdersByCustomer")
            .Produces<GetOrdersByCustomerResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Orders By Customer")
            .WithDescription("Get Orders By Customer");
        }
    }
}
