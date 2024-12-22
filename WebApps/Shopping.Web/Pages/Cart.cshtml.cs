namespace Shopping.Web.Pages
{
    public class CartModel
        (IBasketService basketService, ILogger<CartModel> logger): PageModel
    {
        public ShoppingCartModel Cart = new ShoppingCartModel();

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                Cart = await basketService.LoadUserBasket();
            }
            catch (Exception ex)
            {
                logger.LogError($"Error loading user basket: {ex.Message}");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(Guid productId)
        {
            try
            {
                logger.LogInformation("Remove to cart button clicked");
                Cart = await basketService.LoadUserBasket();
                Cart.Items.RemoveAll(item => item.ProductId == productId);
                await basketService.StoreBasket(new StoreBasketRequest(Cart));
            }
            catch (Exception ex) 
            {
                logger.LogError($"Error removing item from cart: {ex.Message}"); 
            }
            return RedirectToPage();    
        }
    }
}
