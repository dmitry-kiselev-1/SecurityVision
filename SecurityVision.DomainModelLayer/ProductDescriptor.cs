using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SecurityVision.DomainModelLayer
{
    /// <summary>
    /// Класс, описывающий сущность "Описание продукта"
    /// </summary>
    [DataContract(Namespace = "SecurityVisionService")]
    public class ProductDescriptor : ProductDescriptorBase, IEquatable<ProductDescriptor>
    {
        [DataMember(), MaxLength(1024), Display(Name ="Description", ResourceType = typeof(DomainModeResource))]
        public string Description { get; set; }

        [DataMember(), MaxLength(128), Required(), Display(Name = "Name", ResourceType = typeof(DomainModeResource))]
        public string Name { get; set; }

        [DataMember(), Display(Name = "Cost", ResourceType = typeof(DomainModeResource))]
        public int Cost { get; set; }

        [DataMember(), MaxLength(128), Required(), Display(Name = "Manufacturer", ResourceType = typeof(DomainModeResource))]
        public string Manufacturer { get; set; }

        public virtual Product[] ProductCollection { get; set; }

        public bool Equals(ProductDescriptor other)
        {
            return
                this.Id == other.Id &&
                this.Cost == other.Cost &&
                this.Description == other.Description &&
                this.Manufacturer == other.Manufacturer &&
                this.Name == other.Name;
        }
    }
}
