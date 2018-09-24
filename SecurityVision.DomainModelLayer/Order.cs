using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SecurityVision.DomainModelLayer
{
    /// <summary>
    /// Класс, описывающий сущность "Заказ"
    /// </summary>
    [DataContract(Namespace = "SecurityVisionService")]
    public class Order : OrderBase, IEquatable<Order>
    {
        [DataMember(), MaxLength(32), Required(), Display(Name = "OrderNumber", ResourceType = typeof(DomainModeResource))]
        public string OrderNumber { get; set; }

        [DataMember(), Required(), Display(Name = "CreatedOn", ResourceType = typeof(DomainModeResource))]
        public DateTime CreatedOn { get; set; }

        [DataMember(), MaxLength(1024), Display(Name = "Description", ResourceType = typeof(DomainModeResource))]
        public string Description { get; set; }

        public virtual Product[] ProductCollection { get; set; }
        
        public bool Equals(Order other)
        {
            return
                this.Id             == other.Id &&
                this.OrderNumber    == other.OrderNumber && 
                this.Description    == other.Description &&
                this.CreatedOn      == other.CreatedOn;
        }
         
    }
}
