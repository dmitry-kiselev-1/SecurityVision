
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using SecurityVision.DomainModelLayer;

namespace SecurityVisionService
{
    [ServiceContract]
    [DataContractFormat]
    public interface IProductService
    {
        [WebGet(UriTemplate = "/Product",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        [OperationContract(Name = "GetAllProduct")]
        List<Product> GetProduct();

        [WebGet(UriTemplate = "/Order/{id}/Product",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        [OperationContract]
        List<Product> GetProductByOrderId(string id);

        [WebGet(UriTemplate = "/Product/{id}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        [OperationContract]
        Product GetProduct(string id);

        [WebInvoke(Method="POST",
            UriTemplate = "/Product",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        [OperationContract]
        string CreateProduct(Product entity);

        [WebInvoke(Method = "DELETE",
          UriTemplate = "/Product/{id}",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare)]
        [OperationContract]
        void DeleteProduct(string id);

        [WebInvoke(Method = "PUT",
           UriTemplate = "/Product",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Bare)]
        [OperationContract]
        void UpdateProduct(Product entity);
    }
}
