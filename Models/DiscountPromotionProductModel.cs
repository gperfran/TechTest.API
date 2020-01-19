using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechTest.Api.Models
{
    public class DiscountPromotionProductModel
    {
        [Key]
        public int DiscountPromotionProductId { get; set; }
        public string DiscountPromotionId { get; set; }
        public string ProductId { get; set; }
    }
}
 