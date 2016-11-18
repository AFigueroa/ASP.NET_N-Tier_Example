using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACME.DAL;

namespace ACME.BL.Test
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        [TestMethod]
        public void RetrieveExisting()
        {
            // I. Arrange
            var customerRepository = new CustomerRepository();
            var expected = new Customer(1)
            {
                EmailAddress = "test@email.com",
                FirstName = "Antonio",
                LastName = "Figueroa"
            };

            // II. Act
            var actual = customerRepository.Retrieve(1);

            // III. Assert

            // Verify that the expected value matches the actual value
            // Objects must be compared by property values because two identical object are not considered equals and fail comparison.
            Assert.AreEqual(expected.CustomerId, actual.CustomerId);
            Assert.AreEqual(expected.EmailAddress, actual.EmailAddress);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
        }


    }
}
