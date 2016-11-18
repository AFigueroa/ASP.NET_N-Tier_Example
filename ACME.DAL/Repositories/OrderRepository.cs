using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.DAL
{
    public class OrderRepository
    {
        /// <summary>
        /// Retrieve one Order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Order Retrieve(int orderId)
        {
            Order order = new Order(orderId);

            // Temporary hard coded
            if (orderId == 10)
            {
                order.OrderDate = new DateTime(2016, 8, 3);
            }

            return order;
        }

        /// <summary>
        /// Saves the current Order
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            // Saves the defined Order
            return true;
        }
    }
}
