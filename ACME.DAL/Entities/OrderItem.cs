using System.ComponentModel.DataAnnotations;

namespace ACME.DAL
{
    public class OrderItem
    {
        public OrderItem()
        {

        }

        public OrderItem(int orderItemId)
        {
            this.OrderItemId = orderItemId;
        }

        public int OrderItemId { get; private set; }
        public int ItemQuantity { get; set; }
        public Product Product { get; set; }

        private decimal _purchasePrice;
        public decimal PurchasePrice
        {
            get
            {
                // Any logic here
                return _purchasePrice;
            }
            set
            {
                // Multiply the item price by the ammount of items then return it
                var price = Product.CurrentPrice;
                var ammount = ItemQuantity;

                var totalPrice = decimal.Multiply(price, ammount);

                _purchasePrice = totalPrice;
            }
        }

        [Required]
        public Order Order { get; set; }

        /// <summary>
        /// Retrieve order item by Id
        /// </summary>
        /// <param name="orderItemId"></param>
        /// <returns></returns>
        public OrderItem Retrieve(int orderItemId)
        {
            return new OrderItem();
        }

        /// <summary>
        /// Save the Current Order Item
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            // Saves the defined Customer
            return true;
        }
    }
}
