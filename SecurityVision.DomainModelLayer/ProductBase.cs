using System;
using System.Runtime.Serialization;

namespace SecurityVision.DomainModelLayer
{
    [DataContract(Namespace = "SecurityVisionService")]
    [KnownType(typeof(Product))]
    public abstract class ProductBase : EntityBase
    {}
}
