using System;
using System.Collections.Generic;
using ACME.DAL;
using ACME.DAL.DataModel;
using System.Linq;
using System.Data.Entity;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new NullDatabaseInitializer<CustomerContext>());
            //InsertCustomer();
            //InsertMultipleCustomers();
            //SimpleCustomerQueries();
            //CustomerById(1);
            //CustomerByLastName("Figueroa");
            //QueryThenUpdateCustomer();
            DeleteCustomerById(3);
            Console.ReadKey();
        }

        private static void InsertCustomer()
        {
            var customer = new Customer(1)
            {
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

        private static void InsertMultipleCustomers()
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

            var customer2 = new Customer(2)
            {
                FirstName = "Antonio",
                LastName = "Figueroa",
                EmailAddress = "antonioluisfi@aol.com",
                CustomerType = 1,
                AddressList = new List<Address>
                {
                    new Address(21)
                    {
                        AddressType = 1,
                        StreatLine1 = "Lilas 1682",
                        StreetLine2 = "Urb. San Francisco",
                        City = "San Juan",
                        State = "PR",
                        PostalCode = "00927",
                        Country = "U.S"
                    }
                }
            };

            var customer4 = new Customer(4)
            {
                FirstName = "Lourdes",
                LastName = "Garcia",
                EmailAddress = "lourdesga@aol.com",
                CustomerType = 2,
                AddressList = new List<Address>
                {
                    new Address(41)
                    {
                        AddressType = 1,
                        StreatLine1 = "Lilas 1682",
                        StreetLine2 = "Urb. San Francisco",
                        City = "San Juan",
                        State = "PR",
                        PostalCode = "00927",
                        Country = "U.S"
                    }
                }
            };

            var customer3 = new Customer(3)
            {
                FirstName = "Lourdes",
                LastName = "Figueroa",
                EmailAddress = "lulu@gmail.com",
                CustomerType = 2,
                AddressList = new List<Address>
                {
                    new Address(31)
                    {
                        AddressType = 1,
                        StreatLine1 = "College St.",
                        StreetLine2 = "Dorm 1111",
                        City = "SomewhereIn",
                        State = "IA",
                        PostalCode = "55555",
                        Country = "U.S"
                    }
                }
            };

            using (var context = new CustomerContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Customers.AddRange(new List<Customer> {customer, customer2, customer3, customer4 });
                context.SaveChanges();
            }

        }

        private static void SimpleCustomerQueries()
        {
            using (var context = new CustomerContext())
            {
                var customers = context.Customers.ToList();
                var query = context.Customers;

                // one way...
                //var allCustomers = query.ToList();

                // another, but be careful...
                // Will open on the begining of the execution and will 
                // stay open until all the members have been executed
                foreach (var customer in context.Customers)
                {
                    // Database connection init...
                    Console.WriteLine(customer.FullName);
                }
                // Database connection closed.
            }
        }

        private static void CustomerById(int customerId)
        {
            using (var context = new CustomerContext())
            {
                
                var customers = context.Customers.Where(n=> n.CustomerId == customerId);

                foreach (var customer in customers)
                {
                   // Database connection init...
                    Console.WriteLine(customer.FullName);
                }
            }
        }

        private static void CustomerByLastName(string lastName)
        {
            using (var context = new CustomerContext())
            {

                var customers = context.Customers.Where(n => n.LastName == lastName);

                foreach (var customer in customers)
                {
                    // Database connection init...
                    Console.WriteLine(customer.FullName);
                }
            }
        }

        private static void QueryThenUpdateCustomer()
        {
            using(var context = new CustomerContext())
            {
                context.Database.Log = Console.WriteLine;
                var customer = context.Customers.FirstOrDefault();
                customer.FirstName = "Lyntha";
                context.SaveChanges();
            }
        }
        
        private static void DeleteCustomerById(int customerId)
        {
            Customer customer;
            Address address;

            // Delete all found addresses first
            using (var context = new CustomerContext())
            {
                context.Database.Log = Console.WriteLine;
                address = context.Addresses.Find(customerId);
                context.SaveChanges();
            }

            using (var context = new CustomerContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Entry(address).State = EntityState.Deleted;
                context.SaveChanges();
            }

            using (var context = new CustomerContext())
            {
                context.Database.Log = Console.WriteLine;
                customer = context.Customers.Find(customerId);
                context.SaveChanges();
            }

            using (var context = new CustomerContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Entry(customer).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
