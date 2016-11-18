using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACME.Common;
using ACME.Common.Interfaces;

namespace ACME.DAL
{
    public class Product : EntityBase, ILoggable
    {
        public Product()
        {

        }

        public Product(int productId)
        {
            this.ProductId = productId;
        }

        public int ProductId { get; private set; }

        // Decimal? defines a nullable type
        public Decimal? CurrentPrice { get; set; }
        public string ProductDescription { get; set; }
        private String _ProductName;

        // An example of using a Common reusable component
        public String ProductName
        {
            get {
                return _ProductName.InsertSpaces();
            }
            set { _ProductName = value; }
        }

        /// <summary>
        /// Validates that required fields are correct
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrWhiteSpace(ProductName)) isValid = false;
            if (CurrentPrice == null) isValid = false;

            return isValid;
        }

        // Overriding base class's methods
        public override string ToString()
        {
            return ProductName;
        }

        public string Log()
        {
            var logString = this.ProductId + ": " +
                this.ProductName + " " +
                "Detail: " + this.ProductDescription + " " +
                "Status: " + this.EntitySate.ToString();

            return logString;
        }
    }
}
