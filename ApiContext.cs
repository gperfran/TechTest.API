using Microsoft.EntityFrameworkCore;
using System;
using TechTest.Api.Models;

namespace TechTest.Api
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<CustomerModel> Customers{ get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<PointsPromotionModel> PointsPromotions { get; set; }
        public DbSet<DiscountPromotionModel> DiscountPromotions { get; set; }
        public DbSet<DiscountPromotionProductModel> DiscountPromotionProducts { get; set; }

        /// <summary>
        /// Method to preload database in memory
        /// </summary>
        public void Initialize()
        {
            this.Customers.AddRange(
                new CustomerModel { CustomerId = "8e4e8991-aaee-495b-9f24-52d5d0e509c5", LoyaltyCard = "CTX0000001", Name = "Amy" });
            
            this.Products.AddRange(
                new ProductModel { ProductId = "PRD01", ProductName = "Vortex 95", Category = "Fuel", UnitPrice = "1.2" },
                new ProductModel { ProductId = "PRD02", ProductName = "Vortex 98", Category = "Fuel", UnitPrice = "1.3" },
                new ProductModel { ProductId = "PRD03", ProductName = "Diesel", Category = "Fuel", UnitPrice = "1.1" },
                new ProductModel { ProductId = "PRD04", ProductName = "Twix 55g", Category = "Shop", UnitPrice = "2.3" },
                new ProductModel { ProductId = "PRD05", ProductName = "Mars 72g", Category = "Shop", UnitPrice = "5.1" },
                new ProductModel { ProductId = "PRD06", ProductName = "SNICKERS 72G", Category = "Shop", UnitPrice = "3.4" },
                new ProductModel { ProductId = "PRD07", ProductName = "Bounty 3 63g", Category = "Shop", UnitPrice = "6.9" },
                new ProductModel { ProductId = "PRD08", ProductName = "Snickers 50g", Category = "Shop", UnitPrice = "4.0" });

            this.PointsPromotions.AddRange(
                new PointsPromotionModel { PointsPromotionId = "PPD001", PromotionName = "New Year Promo", StartDate = new DateTime(2020, 1, 1), EndDate = new DateTime(2020, 1, 30), Category = "Any", Points = 2 },
                new PointsPromotionModel { PointsPromotionId = "PPD002", PromotionName = "Fuel Promo", StartDate = new DateTime(2020, 2, 5), EndDate = new DateTime(2020, 2, 15), Category = "Fuel", Points = 3 },
                new PointsPromotionModel { PointsPromotionId = "PPD003", PromotionName = "Shop Promo", StartDate = new DateTime(2020, 3, 1), EndDate = new DateTime(2020, 3, 20), Category = "Shop", Points = 4 });

            this.DiscountPromotions.AddRange(
              new DiscountPromotionModel { DiscountPromotionId = "DP001", PromotionName = "Fuel Discount Promo", StartDate = new DateTime(2020, 1, 1), EndDate = new DateTime(2020, 2, 15), DiscountPercentage = 20 },
              new DiscountPromotionModel { DiscountPromotionId = "DP002", PromotionName = "Happy Promo", StartDate = new DateTime(2020, 3, 2), EndDate = new DateTime(2020, 3, 20), DiscountPercentage = 15 });

            this.DiscountPromotionProducts.AddRange(
             new DiscountPromotionProductModel { DiscountPromotionProductId = 1 ,DiscountPromotionId = "DP001", ProductId = "PRD02" });

           this.SaveChanges();
        }
    }
}
