using System.Net;

namespace Shopping.Web.Services
{
    public interface IBasketService
    {
        [Get("/basket-service/basket/{username}")]
        Task<GetBasketResponse> GetBasket(string username);

        [Post("/basket-service/basket")]
        Task<StoreBasketResponse> StoreBasket(StoreBasketRequest request);

        [Delete("/basket-service/basket/{username}")]
        Task<DeleteBasketResponse> DeleteBasket(string username);

        [Post("/basket-service/basket/checkout")]
        Task<CheckoutBasketResponse> CheckoutBasket(CheckoutBasketRequest request);

        public async Task<ShoppingCartModel> LoadUserBasket()
        {
            string username = "ahmed";
            ShoppingCartModel basket;
            try
            {
                GetBasketResponse basketResponse = await GetBasket(username);
                basket = basketResponse.ShoppingCart;
            }
            catch (ApiException apiException) when (apiException.StatusCode == HttpStatusCode.NotFound)
            {
                basket = new ShoppingCartModel
                {
                    UserName = username,
                    Items = []
                };
            }
            return basket;
        }
    }
}
