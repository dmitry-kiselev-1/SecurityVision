
using System.Collections.Generic;
using System.ServiceModel.Activation;
using SecurityVision.DataAccessLayer;
using SecurityVision.DomainModelLayer;

namespace SecurityVisionService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    internal class SecurityVisionService : ISecurityVisionService
    {

        #region Order

            public List<Order> GetOrder()
            {
                return Repository<Order>.Get();
            }

            public Order GetOrder(string id)
            {
                return Repository<Order>.Get(id);
            }

            public string CreateOrder(Order entity)
            {
                return Repository<Order>.Create(entity);
            }

            public void DeleteOrder(string id)
            {
                Repository<Order>.Delete(id);
            }

            public void UpdateOrder(Order entity)
            {
                Repository<Order>.Update(entity);
            }

        #endregion

        #region Product

            public List<Product> GetProduct()
            {
                return Repository<Product>.Get();
            }

            public List<Product> GetProductByOrderId(string id)
            {
                return Repository<Product>.GetByParent<Order, Product>(id);
            }

            public Product GetProduct(string id)
            {
                return Repository<Product>.Get(id);
            }

            public string CreateProduct(Product entity)
            {
                return Repository<Product>.Create(entity);
            }

            public void DeleteProduct(string id)
            {
                Repository<Product>.Delete(id);
            }

            public void UpdateProduct(Product entity)
            {
                Repository<Product>.Update(entity);
            }

        #endregion

        #region ProductDescriptor

            public List<ProductDescriptor> GetProductDescriptor()
            {
                return Repository<ProductDescriptor>.Get();
            }

            public ProductDescriptor GetProductDescriptor(string id)
            {
                return Repository<ProductDescriptor>.Get(id);
            }

            public string CreateProductDescriptor(ProductDescriptor entity)
            {
                return Repository<ProductDescriptor>.Create(entity);
            }

            public void DeleteProductDescriptor(string id)
            {
                Repository<ProductDescriptor>.Delete(id);
            }

            public void UpdateProductDescriptor(ProductDescriptor entity)
            {
                Repository<ProductDescriptor>.Update(entity);
            }

        #endregion
    }
}
