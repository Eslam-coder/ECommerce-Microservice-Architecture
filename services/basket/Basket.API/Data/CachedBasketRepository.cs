using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Basket.API.Data
{
    public class CachedBasketRepository
        (IBasketRepository basketRepository, IDistributedCache distributedCache)
        : IBasketRepository
    {
        public async Task<ShoppingCart> GetBasket(string username, CancellationToken cancellationToken = default)
        {
            //get basket from cache
            var cachedBasket = await distributedCache.GetStringAsync(username, cancellationToken);
            if (!string.IsNullOrEmpty(cachedBasket))
                return JsonSerializer.Deserialize<ShoppingCart>(cachedBasket)!;
            //get basket from Db
            ShoppingCart shoppingCart = await basketRepository.GetBasket(username, cancellationToken);
            //save cart in cache
            await distributedCache.SetStringAsync(username, JsonSerializer.Serialize(shoppingCart), cancellationToken);
            return shoppingCart;
        }

        public async Task<ShoppingCart> StoreBasket(ShoppingCart shoppingCart, CancellationToken cancellationToken = default)
        {
            //save basket in Db
            await basketRepository.StoreBasket(shoppingCart, cancellationToken);
            //save cart in cache
            await distributedCache.SetStringAsync(shoppingCart.UserName, JsonSerializer.Serialize(shoppingCart), cancellationToken);  
            return shoppingCart;
        }

        public async Task<bool> DeleteBasket(string username, CancellationToken cancellationToken)
        {
            //remove cart from cache
            await distributedCache.RemoveAsync(username, cancellationToken);
            //remove cart from Db
            return await basketRepository.DeleteBasket(username, cancellationToken);
        }
    }
}
