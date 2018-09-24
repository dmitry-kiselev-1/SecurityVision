using System;
using System.Collections.Generic;
using System.Linq;
using SecurityVision.DomainModelLayer;

namespace SecurityVision.DataAccessLayer
{
    /// <summary>
    /// Обобщённый репозиторий 
    /// для операций со всеми объектами типа SecurityVision.DomainModelLayer.EntityBase
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class Repository<T> where T : EntityBase
    {
        /// <summary>
        /// Возвращает все сущности заданного типа T из БД
        /// </summary>
        public static List<T> Get()
        {
            using (var db = new SecurityVisionDatabase())
            {
                return db.Set<T>().ToList();
            }
        }

        /// <summary>
        /// Возвращает все сущности заданного типа T из БД,
        /// всех потомков заданного родителя.
        /// </summary>
        /// <typeparam name="TParent">Тип родителя</typeparam>
        /// <typeparam name="TChild">Тип потомка</typeparam>
        /// <param name="parentId">Идентификатор родителя</param>
        public static List<T> GetByParent<TParent, TChild>(string parentId)
        {
            List<T> result = null;

            using (var db = new SecurityVisionDatabase())
            {
                if (typeof(TChild) == typeof(Product) && typeof(TParent) == typeof(Order))
                {
                    int orderId; 
                    int.TryParse(parentId, out orderId);

                    var r = db.Product.Where(p => p.OrderId == orderId);
                    result = ((IEnumerable<T>)r).ToList();
                }
                else if (typeof(TChild) == typeof(ProductDescriptor))
                {}
                else if (typeof(TChild) == typeof(Order))
                {}
            }
            return result;
        }

        /// <summary>
        /// Возвращает единственную сущность заданного типа T из БД, по её идентификатору
        /// </summary>
        public static T Get(string id)
        {
            using (var db = new SecurityVisionDatabase())
            {
                int _id;
                int.TryParse(id, out _id);

                return db.Set<T>().Find(_id);
            }
        }
        
        /// <summary>
        /// Добавляет сущность заданного типа T в БД и возвращает присвоенный ей идентификатор
        /// </summary>
        public static string Create(T entity)
        {
            using (var db = new SecurityVisionDatabase())
            {
                var e = db.Set<T>().Add(entity);
                db.SaveChanges();
                return e.Id.ToString();
            }
        }

        /// <summary>
        /// Удаляет сущность заданного типа T из БД, по её идентификатору
        /// </summary>
        public static void Delete(string id)
        {
            using (var db = new SecurityVisionDatabase())
            {
                int _id;
                int.TryParse(id, out _id);

                var entity = db.Set<T>().Find(_id);
                if (entity != null)
                {
                    db.Set<T>().Remove(entity);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Обновляет сущность заданного типа T из БД
        /// </summary>
        public static void Update(T entity)
        {
            var entityOrder = entity as Order;
            var entityProduct = entity as Product;
            var entityProductDescriptor = entity as ProductDescriptor;

            using (var db = new SecurityVisionDatabase())
            {
                if (entityOrder != null)
                {
                    var databaseEntity = db.Set<Order>().Find(entity.Id);
                    if (databaseEntity != null)
                    {
                        databaseEntity.OrderNumber = entityOrder.OrderNumber;
                        databaseEntity.CreatedOn = entityOrder.CreatedOn;
                        databaseEntity.Description = entityOrder.Description;
                    }
                }
                else if (entityProduct != null)
                {
                    var databaseEntity = db.Set<Product>().Find(entity.Id);
                    if (databaseEntity != null)
                    {
                        databaseEntity.SerialNumber = entityProduct.SerialNumber;
                    }
                }
                else if (entityProductDescriptor != null)
                {
                    var databaseEntity = db.Set<ProductDescriptor>().Find(entity.Id);
                    if (databaseEntity != null)
                    {
                        databaseEntity.Cost = entityProductDescriptor.Cost;
                        databaseEntity.Description = entityProductDescriptor.Description;
                        databaseEntity.Manufacturer = entityProductDescriptor.Manufacturer;
                        databaseEntity.Name = entityProductDescriptor.Name;
                    }
                }
                db.SaveChanges();
            }
        }
    }
}
