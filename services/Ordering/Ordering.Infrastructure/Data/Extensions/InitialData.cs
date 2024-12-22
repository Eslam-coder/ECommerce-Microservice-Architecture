namespace Ordering.Infrastructure.Data.Extensions
{
    public class InitialData
    {
        public static IEnumerable<Customer> Customers => new List<Customer>()
        {
            Customer.Create(CustomerId.Of(new Guid("58c49479-ec65-4de2-86e7-033c546291aa")), "Ahmed", "ahmed@gmail.com"),
            Customer.Create(CustomerId.Of(new Guid("189dc8dc-998f-48e0-a37b-e6f2b60b9d7d")), "Muhammed", "muhammed@gmail.com")
        };

        public static IEnumerable<Product> Products => new List<Product>()
        {
            Product.Create(ProductId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), "Product1", 15),
            Product.Create(ProductId.Of(new Guid("c67d6323-e8b1-4bdf-9a75-b0d8d2e7e914")), "Product2", 35)
        };

        public static IEnumerable<Order> OrdersWithItems 
        {
            get
            {
                Address address1 = new
                (
                "Fawzi",
                "Hassaneen",
                "fawzi@gmail.com",
                "Street5",
                "Cairo",
                "Cairo",
                "1111"
                );

                Address address2 = new
                (
                "Hazem",
                "Fawzi",
                "hazem@gmail.com",
                "Street15",
                "Giza",
                "Giza",
                "3333"
                );

                Payment payment1 = new 
                (
                    "fawzi",
                    "12345678910",
                    "3/28",
                    "333",
                    1
                );

                Order order1 = Order.Create
                (
                    OrderId.Of(Guid.NewGuid()), 
                    CustomerId.Of(new Guid("58c49479-ec65-4de2-86e7-033c546291aa")), 
                    OrderName.Of("ORDER01"), 
                    address1, 
                    address1, 
                    payment1
                 );
                
                order1.AddOrderItem(ProductId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), 2, 30);
                order1.AddOrderItem(ProductId.Of(new Guid("c67d6323-e8b1-4bdf-9a75-b0d8d2e7e914")), 1, 35);

                Payment payment2 = new
                (
                    "hazem",
                    "11121314151617",
                    "5/27",
                    "178",
                    2
                );

                Order order2 = Order.Create
                (
                    OrderId.Of(Guid.NewGuid()),
                    CustomerId.Of(new Guid("189dc8dc-998f-48e0-a37b-e6f2b60b9d7d")),
                    OrderName.Of("ORDER02"),
                    address2,
                    address2,
                    payment2
                 );
                
                order2.AddOrderItem(ProductId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), 1, 15);
                order2.AddOrderItem(ProductId.Of(new Guid("c67d6323-e8b1-4bdf-9a75-b0d8d2e7e914")), 2, 70);
                
                return new List<Order>() { order1, order2 };
            }
        }
    }
}
