namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketRequest(ShoppingCart ShoppingCart);
    
    public record StoreBasketResponse(string Username);
    
    public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
    {
        public StoreBasketCommandValidator()
        {
            RuleFor(command => command.ShoppingCart.UserName)
            .NotEmpty().WithMessage("UserName is required");

            RuleFor(command => command.ShoppingCart)
            .NotNull().WithMessage("Cart can not be null");
        }
    }

    public class StoreBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("basket", async (StoreBasketRequest request, ISender sender) =>
            {
                var command = request.Adapt<StoreBasketCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<StoreBasketResponse>();
                //return response;
                return Results.Created($"/basket/{response.Username}", response);
            })
            .WithName("StoreBasket")
            .Produces<StoreBasketResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Store Basket")
            .WithDescription("Store Basket");
        }
    }
}
