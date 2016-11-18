using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.DAL
{
    public class ProductRepository
    {
        /// <summary>
        /// Retrieve one Product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public Product Retrieve(int productId)
        {
            Product product = new Product(productId);

            // Temporary hard coded
            if(productId == 2)
            {
                product.ProductName = "Snowboard";
                product.ProductDescription = "The best of the best.";
                product.CurrentPrice = 399.99M;
            }

            return product;
        }

        /// <summary>
        /// Saves the current Product
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            // Saves the defined Product
            return true;
        }
    }
}
