using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ACME.BL.Managers;
using ACME.VMS.Customer;

namespace ACME.WEB.Controllers
{
    [Authorize]
    public class CustomerController : ApiController
    {
        public CustomerManager customerManager { get; set; }

        public CustomerController(CustomerManager CustomerManager)
        {
            this.customerManager = CustomerManager;
        }

        // GET api/customer
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/customer/5
        public CustomerViewModel Get(int id)
        {
            return customerManager.GetCustomerById(id);
        }

        // POST api/customer
        public void Post([FromBody]string value)
        {
        }

        // PUT api/customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/customer/5
        public void Delete(int id)
        {
        }
    }
}
