using System;
using System.Runtime.Serialization;

namespace SecurityVision.DomainModelLayer
{
    [DataContract(Namespace = "SecurityVisionService")]
    [KnownType(typeof(Order))]
    public abstract class OrderBase : EntityBase
    {}
}
