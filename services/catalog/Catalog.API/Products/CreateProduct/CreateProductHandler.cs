using FluentValidation;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
    : ICommand<CreateProductResult>;

    public record CreateProductResult(Guid id);
    
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(product => product.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(product => product.Category).NotEmpty().WithMessage("Category is required");
            RuleFor(product => product.ImageFile).NotEmpty().WithMessage("ImageFile is required");
            RuleFor(product => product.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }

    internal class CreateProductCommandHandler 
        (IDocumentSession session)
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken) 
        {
            //var result = await validator.ValidateAsync(command, cancellationToken);
            //var errors = result.Errors.Select(error => error.ErrorMessage).ToList();
            //if (errors.Any())
            //{
            //    throw new ValidationException(errors.FirstOrDefault());
            //}
            Product product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };

            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);
            return new CreateProductResult(product.Id);
        }
    }
}
