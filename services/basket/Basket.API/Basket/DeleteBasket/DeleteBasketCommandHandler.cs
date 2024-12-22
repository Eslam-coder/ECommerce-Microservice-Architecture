
using Basket.API.Data;

namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketResult>;
    
    public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
    {
        public DeleteBasketCommandValidator()
        {
            RuleFor(command => command.UserName).NotEmpty().WithMessage("UserName is required");
        }
    }

    public record DeleteBasketResult(bool IsSuccess);

    public class DeleteBasketCommandHandler(IBasketRepository basketRepository)
        : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
    {
        public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
        {
            bool result = await basketRepository.DeleteBasket(command.UserName, cancellationToken);
            return new DeleteBasketResult(result);
        }
    }
}
