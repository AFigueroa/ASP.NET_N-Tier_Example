using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACME.Common.Interfaces;
using ACME.Common.Services;
using System.Collections.Generic;
using ACME.DAL;

namespace ACME.CommonTest
{
    [TestClass]
    public class LoggingServiceTest
    {
        [TestMethod]
        public void WriteToFileTest()
        {
            var changedItems = new List<ILoggable>();

            var customer = new Customer(1)
            {
                EmailAddress = "test@email.com",
                FirstName = "Antonio",
                LastName = "Figueroa",
                AddressList = null
            };

            changedItems.Add(customer as ILoggable);

            var product = new Product(2)
            {
                ProductName = "Snowboard",
                ProductDescription = "The best of the best.",
                CurrentPrice = 399.99M
            };

            changedItems.Add(product as ILoggable);

            LoggingService.WriteToFile(changedItems);
        }
    }
}
