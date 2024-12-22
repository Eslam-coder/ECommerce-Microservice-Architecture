namespace Shopping.Web.Services
{
    public interface IOrderService
    {
        [Get("/order-service/orders?pageNumber={pageNumber}&pageSize={pageSize}")]
        Task<GetOrdersResponse> GetOrders(int? pageNumber = 1, int? pageSize = 10);

        [Get("/order-service/order/{customerId}")]
        Task<GetOrdersByCustomerResponse> GetOrdersByCustomer(Guid CustomerId);

        [Get("/order-service/orders/{OrderName}")]
        Task<GetOrdersByNameResponse> GetOrdersByName(string OrderName);
    }
}
