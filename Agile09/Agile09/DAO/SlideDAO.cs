using Agile09.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agile09.DAO
{
    public class SlideDAO
    {
        ShopOnlineDb db = null;
        public SlideDAO()
        {
            db = new ShopOnlineDb();
        }
        public List<Slide> GetSlide()
        {
            return db.Slides.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}