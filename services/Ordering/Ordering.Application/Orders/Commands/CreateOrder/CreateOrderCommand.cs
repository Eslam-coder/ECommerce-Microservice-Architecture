namespace Ordering.Application.Orders.Commands.CreateOrder
{
    public record CreateOrderCommand(OrderDto Order)
        :ICommand<CreateOrderCommandResult>;

    public record CreateOrderCommandResult(Guid Id);

    public class CreateOrderCommandValidator: AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator() 
        {
            RuleFor(command => command.Order.OrderName).NotEmpty().WithMessage("Name is required");
            RuleFor(command => command.Order.CustomerId).NotNull().WithMessage("CustomerId is required");
            RuleFor(command => command.Order.OrderItems).NotEmpty().WithMessage("OrderItems should not be empty");
        }
    }
}
