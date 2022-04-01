using Agile09.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agile09.DAO
{
    public class OrderDetailDAO
    {
        ShopOnlineDb db = null;
        public OrderDetailDAO()
        {
            db = new ShopOnlineDb();
        }
        public bool Insert(OrderDetail detail)
        {
            try
            {
                db.OrderDetails.Add(detail);
                db.SaveChanges();
                return true;
            }catch(Exception er)
            {
                return false;
            }
        }
    }
}