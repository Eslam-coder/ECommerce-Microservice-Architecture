using Basket.API.Exceptions;
using Marten;

namespace Basket.API.Data
{
    public class BasketRepository (IDocumentSession session)
        : IBasketRepository
    {
        public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
        {
            var basket = await session.LoadAsync<ShoppingCart>(userName, cancellationToken);
            return basket is null? throw new BasketNotFoundException(userName) : basket;
        }

        public async Task<ShoppingCart> StoreBasket(ShoppingCart shoppingCart, CancellationToken cancellationToken = default)
        {
            session.Store(shoppingCart);
            await session.SaveChangesAsync(cancellationToken);   
            return shoppingCart;
        }

        public async Task<bool> DeleteBasket(string username, CancellationToken cancellationToken)
        {
            session.Delete<ShoppingCart>(username);
            await session.SaveChangesAsync();
            return true;
        }
    }
}
