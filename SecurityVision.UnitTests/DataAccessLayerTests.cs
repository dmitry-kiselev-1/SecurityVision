using System;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityVision.DataAccessLayer;
using SecurityVision.DomainModelLayer;
using System.Linq;
using System.Collections.Generic;

namespace SecurityVision.UnitTest
{
    [TestClass]
    public class DataAccessLayerTests
    {
        /// <summary>
        /// Тест соединения с базой данных. Если база существует и не пуста, тест будет выполнен без ошибок.
        /// Согласно подходу Code-First (Entity Framework), по умолчанию, если базы не существует, она будет создана (по доменной модели).
        /// Также, в этом случае, в ходе теста база будет заполнена тестовыми данными.
        /// </summary>
        [TestMethod]
        public void DataAccessLayer_DatabaseTest()
        {
            try
            {
                // Если раскомментировать данный инициализатор, то база будет пересоздаваться только в случае изменения модели:
                // Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SecurityVisionDatabase>());

                // Если база пуста, она будет заполнена тестовыми данными:
                using (SecurityVisionDatabase db = new SecurityVisionDatabase())
                {
                    if (!db.Order.Any())
                    {
                        var order = db.Order.Add(new Order()
                                                     {
                                                         OrderNumber = "OrderNumber 1",
                                                         CreatedOn = DateTime.Now,
                                                         Description = "Description 1"
                                                     });
                        
                        var productDescriptor = db.ProductDescriptor.Add(new ProductDescriptor()
                                                                             {
                                                                                 Description = "Description 1",
                                                                                 Name = "Name 1",
                                                                                 Cost = 1,
                                                                                 Manufacturer = "Manufacturer 1"
                                                                             });
                        db.Product.Add(new Product()
                                           {
                                               SerialNumber = "SerialNumber 1",
                                               OrderId = order.Id,
                                               ProductDescriptorId = productDescriptor.Id
                                           });

                        db.Product.Add(new Product()
                                           {
                                               SerialNumber = "SerialNumber 2",
                                               OrderId = order.Id,
                                               ProductDescriptorId = productDescriptor.Id
                                           });

                        db.SaveChanges();
                    }
                }
                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }
        }

        /// <summary>
        /// Тест всех методов обобщённого репозитория.
        /// </summary>
        [TestMethod]
        public void DataAccessLayer_RepositoryTest()
        {
            try
            {
                IEnumerable<EntityBase> productCol = Repository<Product>.Get();
                IEnumerable<EntityBase> orderCol = Repository<Order>.Get();
                IEnumerable<EntityBase> productDescriptorCol = Repository<ProductDescriptor>.Get();
                
                int productId = productCol.First().Id;
                EntityBase product = Repository<Product>.Get(productId.ToString());

                int orderId = productCol.First().Id;
                EntityBase order = Repository<Order>.Get(orderId.ToString());

                int productDescriptorId = productDescriptorCol.First().Id;
                EntityBase productDescriptor = Repository<ProductDescriptor>.Get(productDescriptorId.ToString());

                string id = Repository<Order>.Create(new Order()
                {
                    OrderNumber = "OrderNumber",
                    CreatedOn = DateTime.Now,
                    Description = "Description"
                });

                /*
                string id = Repository<Product>.Create(new Product()
                                           {
                                               SerialNumber = "SerialNumber 3",
                                               OrderId = orderId,
                                               ProductDescriptorId = productDescriptorId
                                           });
                */
                //Repository<Product>.Delete(Repository<Product>.Get().Last().Id.ToString());

                IEnumerable<EntityBase> productCol2 = Repository<Product>.GetByParent<Order, Product>(1130.ToString());

                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }
            
        }
    }
}
