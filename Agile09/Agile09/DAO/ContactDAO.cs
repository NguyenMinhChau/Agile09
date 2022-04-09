using Agile09.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agile09.DAO
{
    public class ContactDAO
    {
        ShopOnlineDb db = null;
        public ContactDAO()
        {
            db = new ShopOnlineDb();
        }
        public Contact GetActiveContext()
        {
            return db.Contacts.Single(x => x.Status == true);
        }
        public int InsertFeedBack(Feedback fb)
        {
            db.Feedbacks.Add(fb);
            db.SaveChanges();
            return fb.ID;
        }

    }

}