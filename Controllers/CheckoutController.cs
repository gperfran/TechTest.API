using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TechTest.Api.Models;

namespace TechTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckoutController : ControllerBase
    {
        private readonly ApiContext _context;

        public CheckoutController(ApiContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Checkout API
        /// It will validate the paramenters and apply discount and compute the points
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Checkout([FromBody] CheckoutModel model)
        {
            if (model != null)
            {
                if (_context.Customers.Any(w => w.CustomerId == model.CustomerId && w.LoyaltyCard == model.LoyaltyCard))
                {
                    var transactionDate = Convert.ToDateTime(model.TransactionDate);

                    if (model.Basket != null && model.Basket.Count > 0)
                    {
                        //Get the data first to improve performance
                        var discounts = _context.DiscountPromotions.Where(w => w.StartDate <= transactionDate && w.EndDate >= transactionDate).ToList();
                        var validDiscounts = _context.DiscountPromotionProducts.ToList();

                        //Note: Only one points promo can run at any given time
                        var pointToBeEarned = _context.PointsPromotions.FirstOrDefault(w => w.StartDate <= transactionDate && w.EndDate >= transactionDate);

                        decimal totalAmount = 0;
                        decimal totalPointsEarned = 0;
                        decimal totalDiscount = 0;

                        foreach (var item in model.Basket)
                        {
                            // Convert strings and get the total amount
                            var price = Convert.ToDecimal(item.UnitPrice);
                            var qtde = Convert.ToDecimal(item.Quantity);
                            totalAmount += price * qtde;


                            //Note: Only one points promo can run at any given time
                            if (pointToBeEarned != null)
                            {
                                if (pointToBeEarned.Category == "Any" || pointToBeEarned.Category == _context.Products.FirstOrDefault(w=>w.ProductId== item.ProductId).Category)
                                {
                                    totalPointsEarned += pointToBeEarned.Points;
                                }
                            }

                            //Check if there is any valid discount to be applied
                            if (validDiscounts.Any(w => w.ProductId == item.ProductId) && discounts.Count> 0)
                            {
                                var percentage = discounts.FirstOrDefault(w => w.DiscountPromotionId == validDiscounts.FirstOrDefault(w => w.ProductId == item.ProductId).DiscountPromotionId).DiscountPercentage;
                                totalDiscount += totalAmount * (percentage / 100);
                            }
                        }

                        return Ok(new CheckoutResponseModel
                        {
                            CustomerId = model.CustomerId,
                            LoyaltyCard = model.LoyaltyCard,
                            TransactionDate = model.TransactionDate,
                            TotalAmount = totalAmount,
                            PointsEarned = totalPointsEarned,
                            DiscountApplied= totalDiscount,
                            GrandTotal = totalAmount - totalDiscount
                        });
                    }
                    else
                    {
                        return Content("Basket is empty, there is nothing to checkout");
                    }
                }
                else
                {
                    return Content("Customer or LoyaltyCard not found");
                }
            }
            else
            {
                return Content("Parameter is null");
            }
        }
    }
}
