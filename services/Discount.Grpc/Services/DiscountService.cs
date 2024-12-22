using Discount.Grpc.Data;
using Discount.Grpc.Models_Domain_Layer;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Services
{
    public class DiscountService 
        (DiscountContext discountContext, ILogger<DiscountService> logger)
        : DiscountProtoService.DiscountProtoServiceBase
    {
        public async override Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            Coupon? existingCoupon = await discountContext.Coupons
                                                          .FirstOrDefaultAsync(coupon =>
                                                                                          coupon.ProductName == request.ProductName);
            if (existingCoupon is null)
            {
                return new CouponModel
                {
                    ProductName = "No Discount",
                    Description = "No Discount Disc",
                    Amount = 0
                };
            }
            logger.LogInformation("Discount is retrieved for Product Name: {productName}, Amount: {amount}", existingCoupon?.ProductName, existingCoupon?.Amount);
            return existingCoupon.Adapt<CouponModel>();
        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            Coupon coupon = request.Coupon.Adapt<Coupon>();
            if (request is null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object"));
            discountContext.Coupons.Add(coupon);
            await discountContext.SaveChangesAsync();
            logger.LogInformation("Discount is successfully created for product {productName}", coupon.ProductName);
            return request.Coupon.Adapt<CouponModel>();
        }


        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            Coupon coupon = request.Coupon.Adapt<Coupon>();
            if (request is null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object"));
            discountContext.Coupons.Update(coupon);
            await discountContext.SaveChangesAsync();
            logger.LogInformation("Discount is successfully updated for product {productName}", coupon.ProductName);
            return request.Coupon.Adapt<CouponModel>();
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            Coupon? existingCoupon = await discountContext.Coupons
                                                          .FirstOrDefaultAsync(coupon =>
                                                                               coupon.ProductName == request.ProductName);
            if (existingCoupon is null)
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount with product name: {request.ProductName} is not found"));
            discountContext.Coupons.Remove(existingCoupon);
            await discountContext.SaveChangesAsync();
            logger.LogInformation("Discount with product name: {request.ProductName} is successfully removed.", existingCoupon.ProductName);
            return new DeleteDiscountResponse { Success = true };
        }
    }
}
