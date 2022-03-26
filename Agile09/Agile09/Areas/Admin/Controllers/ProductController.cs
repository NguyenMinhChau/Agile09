using Agile09.DAO;
using Agile09.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agile09.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        [HttpGet]
        public ActionResult Index()
        {
            var dao = new ProductDAO();
            var model = dao.ListAll();
            return View(model.ToList());
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ProductDAO().Delete(id);
            return RedirectToAction("Index");
        }
    }
}