using Basket.API.Data;

namespace Basket.API.Basket.GetBasket
{
    public record GetBasketResult(ShoppingCart ShoppingCart);

    public class GetBasketQueryHandler(IBasketRepository basketRepository)
        : IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
        {
            ShoppingCart cart = await basketRepository.GetBasket(query.UserName, cancellationToken);
            return new GetBasketResult(cart);
        }
    }
}
