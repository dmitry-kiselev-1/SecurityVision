using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using SecurityVision.SilverlightClient.Model;

namespace SecurityVision.SilverlightClient.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Однократно считываемый (в статическом конструкторе) из файла конфигурации адрес REST-сервиса
        /// </summary>
        private static readonly string RestServiceAddress;
        static ViewModelBase()
        {
            RestServiceAddress = SettingsReader.GetAppSetting("RestServiceAddress");
        }

        /// <summary>
        /// Метод заполняет коллекцию заданных сущностей в модели представления, 
        /// оправляя асинхронный GET-запрос к REST-сервису.
        /// </summary>
        /// <typeparam name="T">
        /// По типу сущности определяется, какой необходимо отправить запрос к REST-сервису, 
        /// а также определяется, какая модель представления участвует в процессе.
        /// </typeparam>
        /// <param name="id">Идентификатор извлекаемой сущности, опциональный</param>
        public void SelectAsync<T>(int? id = null)
        {
            var serializer = new DataContractJsonSerializer(typeof(T[]));

            string entityName = typeof(T).Name;
            
            HttpWebRequest httpWebRequest = WebRequest.CreateHttp(RestServiceAddress + entityName 
                + (id.HasValue ? "/" + id : string.Empty));

            httpWebRequest.Method = "GET";

            var r = httpWebRequest.BeginGetResponse(asyncResult =>
            {
                var request = (HttpWebRequest)asyncResult.AsyncState;
                var response = (HttpWebResponse)request.EndGetResponse(asyncResult);
                try
                {
                    var entityArray = (T[])serializer.ReadObject(response.GetResponseStream());
                    var entityObservableCollection = new ObservableCollection<T>(entityArray);

                    if (typeof(T) == typeof(Order))
                    {
                        var entityViewModel = new OrderViewModel() { Orders = entityObservableCollection as ObservableCollection<Order> };
                    }
                    else if (typeof(T) == typeof(Product))
                    {
                        var entityViewModel = new ProductViewModel() { Products = entityObservableCollection as ObservableCollection<Product> };
                    }
                    else if (typeof(T) == typeof(ProductDescriptor))
                    {
                        var entityViewModel = new ProductDescriptorViewModel() { ProductDescriptors = entityObservableCollection as ObservableCollection<ProductDescriptor> };
                    }
                }
                catch (Exception)
                {
                    if (typeof(T) == typeof(Order))
                    {
                        var entityViewModel = new OrderViewModel() { Orders = null };
                    }
                    else if (typeof(T) == typeof(Product))
                    {
                        var entityViewModel = new ProductViewModel() { Products = null };
                    }
                    else if (typeof(T) == typeof(ProductDescriptor))
                    {
                        var entityViewModel = new ProductDescriptorViewModel() { ProductDescriptors = null };
                    }
                }
                RaisePropertyChanged("SelectAsyncCompleted");
            }, httpWebRequest);
        }

        /// <summary>
        /// Метод заполняет коллекцию заданных сущностей в модели представления, 
        /// оправляя асинхронный GET-запрос к REST-сервису.
        /// Извлекаются потомки заданного родителя.
        /// </summary>
        /// <typeparam name="TParent">Тип родителя</typeparam>
        /// <typeparam name="TChild">Тип потомков</typeparam>
        /// <param name="parentId">Идентификатор родителя</param>
        protected void SelectByParentAsync<TParent, TChild>(int parentId)
        {
            var serializer = new DataContractJsonSerializer(typeof(TChild[]));

            string parentEntityName = typeof(TParent).Name;
            string childEntityName = typeof(TChild).Name;

            HttpWebRequest httpWebRequest = WebRequest.CreateHttp(
                RestServiceAddress + parentEntityName + "/" + parentId + "/" + childEntityName);

            httpWebRequest.Method = "GET";

            var r = httpWebRequest.BeginGetResponse(asyncResult =>
            {
                var request = (HttpWebRequest)asyncResult.AsyncState;
                var response = (HttpWebResponse)request.EndGetResponse(asyncResult);
                try
                {
                    var entityArray = (TChild[])serializer.ReadObject(response.GetResponseStream());
                    var entityObservableCollection = new ObservableCollection<TChild>(entityArray);

                    if (typeof(TChild) == typeof(Order))
                    {
                        var entityViewModel = new OrderViewModel() { Orders = entityObservableCollection as ObservableCollection<Order> };
                    }
                    else if (typeof(TChild) == typeof(Product))
                    {
                        var entityViewModel = new ProductViewModel() { Products = entityObservableCollection as ObservableCollection<Product> };
                    }
                    else if (typeof(TChild) == typeof(ProductDescriptor))
                    {
                        var entityViewModel = new ProductDescriptorViewModel() { ProductDescriptors = entityObservableCollection as ObservableCollection<ProductDescriptor> };
                    }
                }
                catch (Exception)
                {
                    if (typeof(TChild) == typeof(Order))
                    {
                        var entityViewModel = new OrderViewModel() { Orders = null };
                    }
                    else if (typeof(TChild) == typeof(Product))
                    {
                        var entityViewModel = new ProductViewModel() { Products = null };
                    }
                    else if (typeof(TChild) == typeof(ProductDescriptor))
                    {
                        var entityViewModel = new ProductDescriptorViewModel() { ProductDescriptors = null };
                    }
                }
                RaisePropertyChanged("SelectByParentAsyncCompleted");
            }, httpWebRequest);
        }

        /// <summary>
        /// Метод удаляет заданную сущность из базы данных, 
        /// оправляя асинхронный DELETE-запрос к REST-сервису.
        /// </summary>
        /// <typeparam name="T">
        /// По типу сущности определяется, какой необходимо отправить запрос к REST-сервису. 
        /// </typeparam>
        /// <param name="id">Идентификатор удаляемой сущности</param>
        protected void DeleteAsync<T>(int id)
        {
            string entityName = typeof(T).Name;

            HttpWebRequest httpWebRequest = WebRequest.CreateHttp(RestServiceAddress + entityName + "/" + id);
            
            httpWebRequest.Method = "DELETE";
            httpWebRequest.BeginGetResponse(asyncResult =>
            {
                var request = (HttpWebRequest)asyncResult.AsyncState;
                var response = (HttpWebResponse)request.EndGetResponse(asyncResult);
                HttpStatusCode statusCode = response.StatusCode;
                RaisePropertyChanged("DeleteAsyncCompleted");
            }, httpWebRequest);
        }

        /// <summary>
        /// Метод обновляет заданную сущность в базе данных, 
        /// оправляя асинхронный PUT-запрос к REST-сервису.
        /// </summary>
        /// <typeparam name="T">
        /// По типу сущности определяется, какой необходимо отправить запрос к REST-сервису. 
        /// </typeparam>
        protected void UpdateAsync<T>(T entity)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));

            string entityName = typeof(T).Name;
            HttpWebRequest httpWebRequest = WebRequest.CreateHttp(RestServiceAddress + entityName);

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
                                                        RaisePropertyChanged("UpdateAsyncCompleted");
                                                    }, httpWebRequest);
        }

        /// <summary>
        /// Метод добавляет заданную сущность в базу данных, 
        /// оправляя асинхронный POST-запрос к REST-сервису.
        /// </summary>
        /// <typeparam name="T">
        /// По типу сущности определяется, какой необходимо отправить запрос к REST-сервису. 
        /// </typeparam>
        protected void CreateAsync<T>(T entity)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));

            string entityName = typeof(T).Name;
            HttpWebRequest httpWebRequest = WebRequest.CreateHttp(RestServiceAddress + entityName);

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
                    int id = int.Parse(Encoding.UTF8.GetString(responseBytes, 0, contentLength).Replace("\"", string.Empty));
                    RaisePropertyChanged("CreateAsyncCompleted");
                }, request);
            }, httpWebRequest);
        }
    }
}
