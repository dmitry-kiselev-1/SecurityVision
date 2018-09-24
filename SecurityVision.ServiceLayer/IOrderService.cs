
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using SecurityVision.DomainModelLayer;

namespace SecurityVisionService
{
    [ServiceContract]
    [DataContractFormat]
    public interface IOrderService
    {
        [WebGet(UriTemplate = "/Order",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        [OperationContract(Name = "GetAllOrder")]
        List<Order> GetOrder();

        [WebGet(UriTemplate = "/Order/{id}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        [OperationContract]
        Order GetOrder(string id);

        [WebInvoke(Method="POST",
            UriTemplate = "/Order",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        [OperationContract]
        string CreateOrder(Order entity);

        [WebInvoke(Method = "DELETE",
          UriTemplate = "/Order/{id}",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare)]
        [OperationContract]
        void DeleteOrder(string id);

        [WebInvoke(Method = "PUT",
           UriTemplate = "/Order",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Bare)]
        [OperationContract]
        void UpdateOrder(Order entity);
    }
}
