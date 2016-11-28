﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.DAL
{
    public class Address
    {
        public Address()
        {

        }

        public Address(int addressId)
        {
            this.AddressId = addressId;
        }

        public int AddressId { get; private set; }
        public int AddressType { get; set; }
        public string StreatLine1 { get; set; }
        public string StreetLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        [Required]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

    }
}
