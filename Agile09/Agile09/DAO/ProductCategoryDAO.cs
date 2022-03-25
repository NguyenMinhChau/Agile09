using Agile09.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agile09.DAO
{
    public class ProductCategoryDAO
    {
        ShopOnlineDb db = null;
        public ProductCategoryDAO()
        {
            db = new ShopOnlineDb();
        }
        public List<ProductCategory> GetCategory()
        {
            return db.ProductCategories.Where(x => x.Status == true).OrderBy(x=>x.DisplayOrder).ToList();
        }
        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategories.Find(id);
        }
    }
}