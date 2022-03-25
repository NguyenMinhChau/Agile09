using Agile09.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agile09.Models;
using Agile09.Common;
using System.Web.Security;

namespace Agile09.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult _Navigation()
        {
            var model = new MenuDAO().ListByGroupID(1);
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult _TopMenu()
        {
            var model = new MenuDAO().ListByGroupID(2);
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult _ProductCategory()
        {
            var model = new ProductCategoryDAO().GetCategory();
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult _Slide()
        {
            var model = new SlideDAO().GetSlide();
            return PartialView(model);

        }
        [ChildActionOnly]
        public ActionResult _Expeditions()
        {
            var model = new ExpeditionsDAO().ListAll(1);
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult _Tours()
        {
            var model = new ToursDAO().ListAll(2);
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult _NewOffers()
        {
            var model = new NewOffersDAO().ListAll(3);
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult _QuantityCart()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }
        public ActionResult Category(long id, int page = 1, int pageSize = 3)
        {
            var category = new CategoryDAO().ViewDetail(id);
            ViewBag.Category = category;
            int totalRecord = 0;
            var model = new ProductDAO().ListByCategoryId(id, ref totalRecord, page, pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;

            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);
        }
        public ActionResult Detail(long id)
        {
            var product = new ProductDAO().ViewDetail(id);
            ViewBag.Category = new ProductCategoryDAO().ViewDetail(product.CategoryID.Value);
            ViewBag.ReletiveProducts = new ProductDAO().ListRelativeProduct(id);
            return View(product);
        }

    }
}