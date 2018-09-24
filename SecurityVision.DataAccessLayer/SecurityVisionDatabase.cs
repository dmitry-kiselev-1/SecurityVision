using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SecurityVision.DomainModelLayer;

namespace SecurityVision.DataAccessLayer
{
    public class SecurityVisionDatabase : DbContext
    {
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductDescriptor> ProductDescriptor { get; set; }
    }
}
