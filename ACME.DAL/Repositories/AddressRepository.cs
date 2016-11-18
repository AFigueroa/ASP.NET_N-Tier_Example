using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.DAL
{
    public class AddressRepository
    {
        /// <summary>
        /// Retrieves an Address by AddressId
        /// </summary>
        /// <param name="addressId"></param>
        /// <returns></returns>
        public Address Retrieve(int addressId)
        {
            Address address = new Address(addressId);

            // Temporarily hard-coded
            if(addressId == 1)
            {
                address.StreatLine1 = "Lilas 1682";
                address.StreetLine2 = "Urb. San Francisco";
                address.City = "San Juan";
                address.State = "PR";
                address.Country = "US";
                address.PostalCode = "00927";
            }
            return address;
        }

        public IEnumerable<Address> RetrieveByCustomerId (int customerId)
        {
            var addressList = new List<Address>();
            Address address = new Address(1)
            {
                AddressType = 1,
                StreatLine1 = "1234 Somewhere St.",
                StreetLine2 = "",
                City = "Paris",
                State = "Île-de-France",
                Country = "France",
                PostalCode = "12345"
            };

            addressList.Add(address);

            address = new Address(2)
            {
                AddressType = 1,
                StreatLine1 = "4321 SomewhereElse St.",
                StreetLine2 = "",
                City = "San Diego",
                State = "California",
                Country = "US",
                PostalCode = "45676"
            };

            addressList.Add(address);

            return addressList;
        }

        /// <summary>
        /// Saves the current Address
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public bool Save(Address address)
        {
            // Save the current adress
            return true;
        }
    }
}
