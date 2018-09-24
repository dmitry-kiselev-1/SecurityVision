using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SecurityVision.DomainModelLayer
{
    /// <summary>
    /// Класс, описывающий сущность "Продукт"
    /// </summary>
    [DataContract(Namespace = "SecurityVisionService")]
    [KnownType(typeof(ProductDescriptor))]
    public class Product : ProductBase, IEquatable<Product>
    {
        [DataMember(), MaxLength(32), Required, Display(Name = "SerialNumber", ResourceType = typeof(DomainModeResource))]
        public string SerialNumber { get; set; }

        /// <summary>
        /// Навигационные свойства, необходимые модели Code First
        /// </summary>
        #region Navigation properties

            public Order Order { get; set; }

            [DataMember]
            public int OrderId { get; set; }

            public ProductDescriptor ProductDescriptor { get; set; }

            [DataMember]
            public int ProductDescriptorId { get; set; }
        
        #endregion

        public bool Equals(Product other)
        {
            return
                this.Id == other.Id &&
                this.OrderId == other.OrderId &&
                this.ProductDescriptorId == other.ProductDescriptorId &&
                this.SerialNumber == other.SerialNumber;
        }
    }
}
