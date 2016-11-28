using System;
using System.Collections.Generic;
using ACME.DAL;
using ACME.DAL.DataModel;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertCustomer();
            Console.ReadKey();
        }

        private static void InsertCustomer()
        {
            var customer = new Customer(1) {
                FirstName = "Antonio",
                LastName = "Figueroa",
                EmailAddress = "antonio.figueroa@synechron.com",
                CustomerType = 1,
                AddressList = new List<Address>
                {
                    new Address(1)
                    {
                        AddressType = 1,
                        StreatLine1 = "2420 Old Brick Rd.",
                        StreetLine2 = "Apt. 1419",
                        City = "Glen Allen",
                        State = "VA",
                        PostalCode = "23060",
                        Country = "U.S"
                    }
                }
            };

            using (var context = new CustomerContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Customers.Add(customer);
                context.SaveChanges();
            }

        }
    }
}
