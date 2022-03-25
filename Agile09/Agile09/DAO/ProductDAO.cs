using Agile09.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agile09.DAO
{
    public class ProductDAO
    {
        ShopOnlineDb db = null;
        public ProductDAO()
        {
            db = new ShopOnlineDb();
        }
        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }
        public List<Product> ListRelativeProduct(long productID)
        {
            var product = db.Products.Find(productID);
            return db.Products.Where(x => x.ID != productID && x.CategoryID == product.CategoryID).ToList();
        }
        public List<Product> ListByCategoryId(long categoryID, ref int totalRecord, int page=1, int pageSize=2)
        {
            totalRecord = db.Products.Where(x => x.CategoryID == categoryID).Count();
            var model = db.Products.Where(x => x.CategoryID == categoryID).OrderByDescending(x=>x.CreatedDate).Skip((page - 1)* pageSize).Take(pageSize).ToList();
            return model;
        }
        public IEnumerable<Product> ListAll()
        {
            return db.Products;
        }
        public long Insert(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public Product GetByID(long id)
        {
            return db.Products.Find(id);
        }
        public bool Update(Product entity)
        {
            try
            {
                var product = db.Products.Find(entity.ID);
                product.Name = entity.Name;
                product.Code = entity.Code;
                product.MetaTitle = entity.MetaTitle;
                product.Description = entity.Description;
                product.Image = entity.Image;
                product.Price = entity.Price;
                product.PromotionPrice = entity.PromotionPrice;
                product.IncludedVAT = entity.IncludedVAT;
                product.Quantity = entity.Quantity;
                product.CategoryID = entity.CategoryID;
                product.Detail = entity.Detail;
                product.Warranty = entity.Warranty;
                product.CreatedBy = entity.CreatedBy;
                product.CreatedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception er)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var content = db.Products.Find(id);
                db.Products.Remove(content);
                db.SaveChanges();
                return true;
            }
            catch (Exception er)
            {
                return false;
            }
        }
        
    }
}