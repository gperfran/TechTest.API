using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechTest.Api.Models
{
    public class ProductModel
    {
        [Key]
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string UnitPrice { get; set; }
        public string Quantity { get; set; }
    }
}
 