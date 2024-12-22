namespace Shopping.Web.Pages
{
    public class ProductListModel
        (ILogger<ProductListModel> logger,
         ICatalogService catalogService,
         IBasketService basketService) : PageModel
    {
        public IEnumerable<ProductModel> ProductList { get; set; } = [];

        public IEnumerable<string> CategoryList { get; set; } = [];

        [BindProperty(SupportsGet = true)]
        public string SelectedCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string categoryName)
        {
            GetProductsResponse response = await catalogService.GetProducts();
            CategoryList = response.Products.SelectMany(product => product.Category).Distinct();
            if (!string.IsNullOrWhiteSpace(categoryName))
            {
                ProductList = response.Products.Where(product => product.Category.Contains(categoryName));
                SelectedCategory = categoryName;
            }
            else
            {
                ProductList = response.Products;
            }
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
