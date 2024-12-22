using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if (await session.Query<Product>().AnyAsync())
                return;

            session.Store<Product>(GetPreconfiguredProducts());
            await session.SaveChangesAsync();
        }

        private static IEnumerable<Product> GetPreconfiguredProducts() =>
            new List<Product>()
            {
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Name",
                    Description = "Description",
                    Category = ["category"],
                    ImageFile = "ImageFile",
                    Price = 15
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Name2",
                    Description = "Description2",
                    Category = ["category2"],
                    ImageFile = "ImageFile",
                    Price = 150
                }
            };
    };
}
