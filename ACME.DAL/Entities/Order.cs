using ACME.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.DAL
{
    public class Order : EntityBase, ILoggable
    {
        public Order()
        {
                
        }

        public Order(int orderId)
        {
            this.OrderId = orderId;
        }

        public DateTimeOffset? OrderDate { get; set; }
        public int OrderId { get; private set; }

        public string Log()
        {
            var logString = this.OrderId + ": " +
                "Date: " + this.OrderDate.Value.Date + " " +
                "Status: " + this.EntitySate.ToString();

            return logString;
        }

        public override bool Validate()
        {
            var isValid = true;

            if (OrderDate != null) isValid = false;

            return isValid;
        }
    }

}
