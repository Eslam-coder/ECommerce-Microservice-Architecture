﻿
using Basket.API.Data;
using BuildingBlocks.Messaging.Events;
using MassTransit;

namespace Basket.API.Basket.CheckoutBasket
{
    public record CheckoutBasketCommand(BasketCheckoutDto BasketCheckoutDto)
        : ICommand<CheckoutBasketResult>;
    
    public record CheckoutBasketResult(bool IsSuccess);

    public class CheckoutBasketCommandValidator : AbstractValidator<CheckoutBasketCommand>
    {
        public CheckoutBasketCommandValidator()
        {
            RuleFor(command => command.BasketCheckoutDto).NotNull()
                                                         .WithMessage("CheckoutBasketDto can't be null");
            RuleFor(command => command.BasketCheckoutDto.UserName).NotEmpty()
                                                                  .WithMessage("UserName is required");
        }
    }
    public class CheckoutBasketCommandHandler
        (IBasketRepository basketRepository, IPublishEndpoint publishEndpoint)
        : ICommandHandler<CheckoutBasketCommand, CheckoutBasketResult>
    { 
        public async Task<CheckoutBasketResult> Handle(CheckoutBasketCommand command, CancellationToken cancellationToken)
        {
            var basket = await basketRepository.GetBasket(command.BasketCheckoutDto.UserName, cancellationToken);
            if (basket == null)
            {
                return new CheckoutBasketResult(false);
            }
            
            var eventMessage = command.BasketCheckoutDto.Adapt<BasketCheckoutEvent>();
            eventMessage.TotalPrice = basket.TotalPrice;
            try
            {
                await publishEndpoint.Publish(eventMessage, cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to publish event: {ex.Message}");
                throw;
            }
            
            await basketRepository.DeleteBasket(command.BasketCheckoutDto.UserName, cancellationToken);
            return new CheckoutBasketResult(true);
        }
    }
}