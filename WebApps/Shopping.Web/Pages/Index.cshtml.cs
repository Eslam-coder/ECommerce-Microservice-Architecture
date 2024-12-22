using System.Net;

namespace Shopping.Web.Pages
{
    public class IndexModel (
        ILogger<IndexModel> logger,
        ICatalogService catalogService,
        IBasketService basketService) : PageModel
    { 
        public IEnumerable<ProductModel> ProductList = new List<ProductModel>();

        public async Task<IActionResult> OnGetAsync()
        {
            logger.LogInformation("Index paged visited");
            GetProductsResponse result = await catalogService.GetProducts();
            //GetProductsResponse result = await catalogService.GetProducts(2, 3);
            ProductList = result.Products;
            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(Guid productId)
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
            return RedirectToPage("cart");
        }
    }
}
