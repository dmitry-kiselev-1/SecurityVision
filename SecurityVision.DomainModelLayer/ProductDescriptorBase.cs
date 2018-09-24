using System;
using System.Runtime.Serialization;

namespace SecurityVision.DomainModelLayer
{
    [DataContract(Namespace = "SecurityVisionService")]
    [KnownType(typeof(ProductDescriptor))]
    public abstract class ProductDescriptorBase : EntityBase
    {}
}
