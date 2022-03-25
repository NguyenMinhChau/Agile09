using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agile09.EF;

namespace Agile09.DAO
{
    public class CategoryDAO
    {
        ShopOnlineDb db = null;
        public CategoryDAO()
        {
            db  = new ShopOnlineDb();
        }
        public List<Category> ListAll()
        {
            return db.Categories.Where(x => x.Status == true).ToList();
        }
        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategories.Find(id);
        }
    }
}