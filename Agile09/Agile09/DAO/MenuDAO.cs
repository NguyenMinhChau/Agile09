using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agile09.EF;

namespace Agile09.DAO
{
    public class MenuDAO
    {
        ShopOnlineDb db = null;
        public MenuDAO()
        {
            db = new ShopOnlineDb();
        }
        public List<Menu> ListByGroupID(int groupID)
        {
            return db.Menus.Where(x => x.TypeID == groupID && x.Status ==true).OrderBy(x=>x.DisplayOrder).ToList();
        }
    }
}