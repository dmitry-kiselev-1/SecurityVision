
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using SecurityVision.DomainModelLayer;

namespace SecurityVisionService
{
    [ServiceContract]
    [DataContractFormat]
    public interface IProductDescriptorService
    {
        [WebGet(UriTemplate = "/ProductDescriptor",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        [OperationContract(Name = "GetAllProductDescriptor")]
        List<ProductDescriptor> GetProductDescriptor();

        [WebGet(UriTemplate = "/ProductDescriptor/{id}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        [OperationContract]
        ProductDescriptor GetProductDescriptor(string id);

        [WebInvoke(Method="POST",
            UriTemplate = "/ProductDescriptor",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        [OperationContract]
        string CreateProductDescriptor(ProductDescriptor entity);

        [WebInvoke(Method = "DELETE",
          UriTemplate = "/ProductDescriptor/{id}",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare)]
        [OperationContract]
        void DeleteProductDescriptor(string id);

        [WebInvoke(Method = "PUT",
           UriTemplate = "/ProductDescriptor",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Bare)]
        [OperationContract]
        void UpdateProductDescriptor(ProductDescriptor entity);
    }
}
