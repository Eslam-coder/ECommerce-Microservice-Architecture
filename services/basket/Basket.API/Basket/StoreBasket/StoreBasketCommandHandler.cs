using Basket.API.Data;
using Discount.Grpc;
using static Discount.Grpc.DiscountProtoService;

namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart ShoppingCart) : ICommand<StoreBasketResult>;

    public record StoreBasketResult(string Username);
    
    public class StoreBasketCommandHandler
        (IBasketRepository basketRepository, DiscountProtoServiceClient discountProto)
        : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {
            await DeductDiscount(command.ShoppingCart);
            await basketRepository.StoreBasket(command.ShoppingCart, cancellationToken);
            return new StoreBasketResult(command.ShoppingCart.UserName);
        }

        private async Task DeductDiscount(ShoppingCart shoppingCart)
        {
            foreach (var item in shoppingCart.Items)
            {
                var coupon = await discountProto.GetDiscountAsync(new GetDiscountRequest { ProductName = item.ProductName });
                item.Price -= coupon.Amount;
            }
        }
    }
}
