using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACME.VMS.Customer;
using ACME.DAL;

namespace ACME.BL.Managers
{
    public class CustomerManager
    {
        public CustomerRepository customerRepository { get; set; }

        public CustomerViewModel GetCustomerById (int customerId)
        {
            // Get the customer details
            var customer = this.customerRepository.Retrieve(customerId);

            // Map it to the view model
            var model = new CustomerViewModel()
            {
                EmailAddres = customer.EmailAddress,
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                FullName = customer.FullName
            };

            // Return the view model
            return model;
            
        }
    }
}
