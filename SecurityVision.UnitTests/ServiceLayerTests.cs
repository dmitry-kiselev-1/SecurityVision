using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityVision.DomainModelLayer;

namespace SecurityVision.UnitTest
{
    [TestClass]
    public class ServiceLayerTests
    {
        [TestMethod]
        public void ServiceLayer_GET_Test()
        {
            try
            {
                // GET
                var serializer = new DataContractJsonSerializer(typeof(Order[]));
                HttpWebRequest httpWebRequest = WebRequest.CreateHttp("http://localhost:50500/SecurityVisionService/Order/1130/Product");
                //HttpWebRequest httpWebRequest = WebRequest.CreateHttp("http://localhost:50500/SecurityVisionService/Order");
                httpWebRequest.BeginGetResponse(asyncResult =>
                                                {
                                                    var request = (HttpWebRequest)asyncResult.AsyncState;
                                                    var response = (HttpWebResponse)request.EndGetResponse(asyncResult);
                                                    var entityArray = serializer.ReadObject(response.GetResponseStream());
                                                }, httpWebRequest);
                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }
        }

        [TestMethod]
        public void ServiceLayer_POST_Test()
        {
            try
            {
                // POST
                Order entity = new Order() { Description = "Новый", CreatedOn = DateTime.Now, OrderNumber = "100" };
                var serializer = new DataContractJsonSerializer(typeof(Order));
                HttpWebRequest httpWebRequest = WebRequest.CreateHttp("http://localhost:50500/SecurityVisionService/Order");
                httpWebRequest.Method = "POST";
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.BeginGetRequestStream(asyncResultRequest =>
                                                     {
                                                         var request = (HttpWebRequest)asyncResultRequest.AsyncState;
                                                         Stream requestStream = request.EndGetRequestStream(asyncResultRequest);
                                                         serializer.WriteObject(requestStream, entity);
                                                         requestStream.Close();

                                                         request.BeginGetResponse(asyncResultResponse =>
                                                                                  {
                                                                                      var response = (HttpWebResponse)request.EndGetResponse(asyncResultResponse);
                                                                                      Stream responseStream = response.GetResponseStream();
                                                                                      int contentLength = (int)response.ContentLength;
                                                                                      byte[] responseBytes = new byte[contentLength];
                                                                                      responseStream.Read(responseBytes, 0, contentLength);
                                                                                      int id = int.Parse(Encoding.UTF8.GetString(responseBytes, 0, contentLength)
                                                                                          .Replace("\"" , string.Empty));
                                                                                  }, request);
                                                     }, httpWebRequest);
            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }
        }

        [TestMethod]
        public void ServiceLayer_PUT_Test()
        {
            try
            {
                // PUT
                Order entity = new Order() {Id = 1012, Description = "Старый", CreatedOn = DateTime.Now, OrderNumber = "100" };
                var serializer = new DataContractJsonSerializer(typeof(Order));
                HttpWebRequest httpWebRequest = WebRequest.CreateHttp("http://localhost:50500/SecurityVisionService/Order");
                httpWebRequest.Method = "PUT";
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.BeginGetRequestStream(asyncResultRequest =>
                                                     {
                                                         var request = (HttpWebRequest)asyncResultRequest.AsyncState;
                                                         Stream requestStream = request.EndGetRequestStream(asyncResultRequest);
                                                         serializer.WriteObject(requestStream, entity);
                                                         requestStream.Close();

                                                         request.BeginGetResponse(asyncResultResponse =>
                                                                                  {
                                                                                      var response = (HttpWebResponse)request.EndGetResponse(asyncResultResponse);
                                                                                      HttpStatusCode statusCode = response.StatusCode;
                                                                                  }, request);
                                                     }, httpWebRequest);
            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }
        }

        [TestMethod]
        public void ServiceLayer_DELETE_Test()
        {
            try
            {
                // DELETE
                HttpWebRequest httpWebRequest = WebRequest.CreateHttp("http://localhost:50500/SecurityVisionService/Order/1012");
                httpWebRequest.Method = "DELETE";
                httpWebRequest.BeginGetResponse(asyncResult =>
                                                {
                                                    var request = (HttpWebRequest) asyncResult.AsyncState;
                                                    var response = (HttpWebResponse) request.EndGetResponse(asyncResult);
                                                    HttpStatusCode statusCode = response.StatusCode;
                                                }, httpWebRequest);
            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }
        }
    }
}
