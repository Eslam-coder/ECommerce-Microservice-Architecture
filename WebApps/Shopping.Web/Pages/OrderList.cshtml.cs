namespace Shopping.Web.Pages
{
    public class OrderListModel
        (ILogger<OrderListModel> logger,
         IOrderService orderService) : PageModel
    {
        public IEnumerable<OrderModel> Orders { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                Guid CustomerId = new Guid("58c49479-ec65-4de2-86e7-033c546291aa");
                GetOrdersByCustomerResponse response = await orderService.GetOrdersByCustomer(CustomerId);
                Orders = response.Orders;
            }
            catch (Exception exception)
            {
                logger.LogError("An Error occured when getting orders: {message}", exception.Message);
                throw;
            }
            return Page();
        }
    }
}
