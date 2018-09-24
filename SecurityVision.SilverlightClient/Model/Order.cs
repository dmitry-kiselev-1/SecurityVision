
using System;

namespace SecurityVision.SilverlightClient.Model
{
    public class Order : SecurityVisionServiceReference.Order, IEquatable<Order>
    {
        public bool Equals(Order other)
        {
            return
                this.Id == other.Id &&
                this.OrderNumber == other.OrderNumber &&
                this.Description == other.Description &&
                this.CreatedOn == other.CreatedOn;
        }
    }
}
