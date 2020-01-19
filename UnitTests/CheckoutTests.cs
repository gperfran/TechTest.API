using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechTest.Api.UnitTests
{
    [TestClass]
    public class CheckoutTests
    {
        private readonly ApiContext _context;

        public CheckoutTests(ApiContext context)
        {
            _context = context;
        }

        [TestMethod]
        [TestCategory("Unit Test")]
        public void InvalidCustomer()
        {
            var customer = _context.Customers.FirstOrDefault(w => w.CustomerId == "8ae4e8991-aaee-495b-9f24-52d5d0e509c5");

            Assert.AreEqual(customer.CustomerId, "8e4e8991-aaee-495b-9f24-52d5d0e509c5");
        }
    }
}
