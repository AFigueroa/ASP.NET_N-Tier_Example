using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.DAL
{
    public class CustomerRepository
    {
        private AddressRepository addressRepository { get; set; }

        public CustomerRepository()
        {
            addressRepository = new AddressRepository();
        }
        
        // Methods can share a namespace aslong as their parameters differ this is called signature.
        /// <summary>
        /// Retrieve a customer by it's id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public Customer Retrieve(int customerId)
        {
            // Pass in the value of the id to set it in the class constructor
            Customer customer = new Customer(customerId);
            customer.AddressList = addressRepository.RetrieveByCustomerId(customerId).ToList();
            // Temporarily hard coded
            if(customerId == 1)
            {
                customer.EmailAddress = "test@email.com";
                customer.FirstName = "Antonio";
                customer.LastName = "Figueroa";
            }

            return customer;
        }

        /// <summary>
        /// Retrieve a list of all customers
        /// </summary>
        /// <returns></returns>
        public List<Customer> Retrieve()
        {
            return new List<Customer>();
        }

        /// <summary>
        /// Saves the current Customer
        /// </summary>
        /// <returns></returns>
        public bool Save(Customer customer)
        {
            // Saves the defined Customer
            return true;
        }
    }
}
