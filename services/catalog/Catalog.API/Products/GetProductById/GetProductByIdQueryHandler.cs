namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdQuery(Guid id) : IQuery<GetProductByIdResult>;

    public record GetProductByIdResult(Product Product);

    public class GetProductByIdQueryHandler
        (IDocumentSession session)
        //(IDocumentSession session, ILogger<GetProductByIdQueryHandler> logger)
        : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(query.id);
            if(product is null)
            {
                throw new ProductNotFoundException(query.id);
            }
            return new GetProductByIdResult(product);
        }
    }
}
