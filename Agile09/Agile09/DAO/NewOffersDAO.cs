using Agile09.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agile09.DAO
{
    public class NewOffersDAO
    {
        ShopOnlineDb db = null;
        public NewOffersDAO()
        {
            db = new ShopOnlineDb();
        }
        public List<Product> ListAll(int id)
        {
            return db.Products.Where(x => x.Status == true && x.Warranty == 3).ToList();
        }
    }
}