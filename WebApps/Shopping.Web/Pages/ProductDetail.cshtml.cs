namespace Shopping.Web.Pages
{
    public class ProductDetailModel
        (ILogger<ProductDetailModel> logger,
         ICatalogService catalogService,
         IBasketService basketService) : PageModel
    {
        public ProductModel Product { get; set; } = default!;

        [BindProperty]
        public string Color { get; set; } = default!;

        [BindProperty]
        public int Quantity { get; set; } = default!;

        public async Task<IActionResult> OnGet(Guid productId)
        {
            var response = await catalogService.GetProductById(productId);
            Product = response.Product;
            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(Guid productId)
        {
            try 
            {
                logger.LogInformation("Add to cart button clicked");
                GetProductByIdResponse productResponse = await catalogService.GetProductById(productId);
                var basket = await basketService.LoadUserBasket();
                basket.Items.Add(new ShoppingCartItemModel
                {
                    ProductId = productId,
                    ProductName = productResponse.Product.Name,
                    Price = productResponse.Product.Price,
                    Quantity = 1,
                    Color = "Black"
                });
                await basketService.StoreBasket(new StoreBasketRequest(basket));
            }
            catch (Exception ex) 
            {
                logger.LogError($"Error adding item to cart: {ex.Message}");
            }
            return RedirectToPage("Cart");
        }
    }
}
