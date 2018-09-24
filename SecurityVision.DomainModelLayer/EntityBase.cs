using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SecurityVision.DomainModelLayer
{
    /// <summary>
    /// Базовый класс для всех сущностей доменной модели
    /// </summary>
    [DataContract(Namespace = "SecurityVisionService")]
    [KnownType(typeof(ProductBase))]
    [KnownType(typeof(OrderBase))]
    [KnownType(typeof(ProductDescriptorBase))]
    public abstract class EntityBase
    {
        [DataMember]
        public int Id { get; set; }
    }
}
