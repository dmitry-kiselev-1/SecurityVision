﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.18052
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SecurityVision.UnitTest.SecurityVisionServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SecurityVisionServiceReference.ISecurityVisionService")]
    internal interface ISecurityVisionService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/GetAllOrder", ReplyAction="http://tempuri.org/IOrderService/GetAllOrderResponse")]
        SecurityVision.DomainModelLayer.Order[] GetAllOrder();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/GetOrder", ReplyAction="http://tempuri.org/IOrderService/GetOrderResponse")]
        SecurityVision.DomainModelLayer.Order GetOrder(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/CreateOrder", ReplyAction="http://tempuri.org/IOrderService/CreateOrderResponse")]
        string CreateOrder(SecurityVision.DomainModelLayer.Order entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/DeleteOrder", ReplyAction="http://tempuri.org/IOrderService/DeleteOrderResponse")]
        void DeleteOrder(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/UpdateOrder", ReplyAction="http://tempuri.org/IOrderService/UpdateOrderResponse")]
        void UpdateOrder(SecurityVision.DomainModelLayer.Order entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetAllProduct", ReplyAction="http://tempuri.org/IProductService/GetAllProductResponse")]
        SecurityVision.DomainModelLayer.Product[] GetAllProduct();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetProductByOrderId", ReplyAction="http://tempuri.org/IProductService/GetProductByOrderIdResponse")]
        SecurityVision.DomainModelLayer.Product[] GetProductByOrderId(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetProduct", ReplyAction="http://tempuri.org/IProductService/GetProductResponse")]
        SecurityVision.DomainModelLayer.Product GetProduct(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/CreateProduct", ReplyAction="http://tempuri.org/IProductService/CreateProductResponse")]
        string CreateProduct(SecurityVision.DomainModelLayer.Product entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/DeleteProduct", ReplyAction="http://tempuri.org/IProductService/DeleteProductResponse")]
        void DeleteProduct(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/UpdateProduct", ReplyAction="http://tempuri.org/IProductService/UpdateProductResponse")]
        void UpdateProduct(SecurityVision.DomainModelLayer.Product entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductDescriptorService/GetAllProductDescriptor", ReplyAction="http://tempuri.org/IProductDescriptorService/GetAllProductDescriptorResponse")]
        SecurityVision.DomainModelLayer.ProductDescriptor[] GetAllProductDescriptor();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductDescriptorService/GetProductDescriptor", ReplyAction="http://tempuri.org/IProductDescriptorService/GetProductDescriptorResponse")]
        SecurityVision.DomainModelLayer.ProductDescriptor GetProductDescriptor(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductDescriptorService/CreateProductDescriptor", ReplyAction="http://tempuri.org/IProductDescriptorService/CreateProductDescriptorResponse")]
        string CreateProductDescriptor(SecurityVision.DomainModelLayer.ProductDescriptor entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductDescriptorService/DeleteProductDescriptor", ReplyAction="http://tempuri.org/IProductDescriptorService/DeleteProductDescriptorResponse")]
        void DeleteProductDescriptor(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductDescriptorService/UpdateProductDescriptor", ReplyAction="http://tempuri.org/IProductDescriptorService/UpdateProductDescriptorResponse")]
        void UpdateProductDescriptor(SecurityVision.DomainModelLayer.ProductDescriptor entity);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    internal interface ISecurityVisionServiceChannel : SecurityVision.UnitTest.SecurityVisionServiceReference.ISecurityVisionService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    internal partial class SecurityVisionServiceClient : System.ServiceModel.ClientBase<SecurityVision.UnitTest.SecurityVisionServiceReference.ISecurityVisionService>, SecurityVision.UnitTest.SecurityVisionServiceReference.ISecurityVisionService {
        
        public SecurityVisionServiceClient() {
        }
        
        public SecurityVisionServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SecurityVisionServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SecurityVisionServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SecurityVisionServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public SecurityVision.DomainModelLayer.Order[] GetAllOrder() {
            return base.Channel.GetAllOrder();
        }
        
        public SecurityVision.DomainModelLayer.Order GetOrder(string id) {
            return base.Channel.GetOrder(id);
        }
        
        public string CreateOrder(SecurityVision.DomainModelLayer.Order entity) {
            return base.Channel.CreateOrder(entity);
        }
        
        public void DeleteOrder(string id) {
            base.Channel.DeleteOrder(id);
        }
        
        public void UpdateOrder(SecurityVision.DomainModelLayer.Order entity) {
            base.Channel.UpdateOrder(entity);
        }
        
        public SecurityVision.DomainModelLayer.Product[] GetAllProduct() {
            return base.Channel.GetAllProduct();
        }
        
        public SecurityVision.DomainModelLayer.Product[] GetProductByOrderId(string id) {
            return base.Channel.GetProductByOrderId(id);
        }
        
        public SecurityVision.DomainModelLayer.Product GetProduct(string id) {
            return base.Channel.GetProduct(id);
        }
        
        public string CreateProduct(SecurityVision.DomainModelLayer.Product entity) {
            return base.Channel.CreateProduct(entity);
        }
        
        public void DeleteProduct(string id) {
            base.Channel.DeleteProduct(id);
        }
        
        public void UpdateProduct(SecurityVision.DomainModelLayer.Product entity) {
            base.Channel.UpdateProduct(entity);
        }
        
        public SecurityVision.DomainModelLayer.ProductDescriptor[] GetAllProductDescriptor() {
            return base.Channel.GetAllProductDescriptor();
        }
        
        public SecurityVision.DomainModelLayer.ProductDescriptor GetProductDescriptor(string id) {
            return base.Channel.GetProductDescriptor(id);
        }
        
        public string CreateProductDescriptor(SecurityVision.DomainModelLayer.ProductDescriptor entity) {
            return base.Channel.CreateProductDescriptor(entity);
        }
        
        public void DeleteProductDescriptor(string id) {
            base.Channel.DeleteProductDescriptor(id);
        }
        
        public void UpdateProductDescriptor(SecurityVision.DomainModelLayer.ProductDescriptor entity) {
            base.Channel.UpdateProductDescriptor(entity);
        }
    }
}
