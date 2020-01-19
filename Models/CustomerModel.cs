using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechTest.Api.Models
{
    public class CustomerModel
    {
        [Key]
        public string CustomerId { get; set; }
        public string LoyaltyCard { get; set; }
        public string Name { get; internal set; }
    }
}
 