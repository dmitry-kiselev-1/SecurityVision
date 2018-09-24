
using System.ServiceModel;

namespace SecurityVisionService
{
    [ServiceContract]
    [DataContractFormat]
    public interface ISecurityVisionService : IOrderService, IProductService, IProductDescriptorService
    {}
}
