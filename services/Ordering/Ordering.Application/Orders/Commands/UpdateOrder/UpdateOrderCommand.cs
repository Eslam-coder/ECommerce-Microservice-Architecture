namespace Ordering.Application.Orders.Commands.UpdateOrder
{
    public record UpdateOrderCommand(OrderDto order) : ICommand<UpdateOrderCommandResult>;

    public record UpdateOrderCommandResult(bool IsSuccess);

    public class UpdateOrderCommandValidator: AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator() 
        {
            RuleFor(command => command.order.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(command => command.order.CustomerId).NotNull().WithMessage("CustomerId is required");
            RuleFor(command => command.order.OrderName).NotEmpty().WithMessage("Name is required");
        }
    }
}
