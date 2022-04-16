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
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDAO();
                long res = dao.Insert(model);
                if (res > 0)
                {
                    SetAlert("Thêm sản phẩm thành công", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    SetAlert("Thêm sản phẩm không thành công", "error");
                    return RedirectToAction("Index", "Product");
                }
            }
            SetAlert("Thêm sản phẩm không thành công", "error");
            return RedirectToAction("Index", "Product");
        }
        protected void SetAlert(string mess, string type)
        {
            TempData["AlertMessage"] = mess;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new ProductDAO();
            var content = dao.GetByID(id);
            return View(content);
        }
        [HttpPost]
        public ActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDAO();
                bool res = dao.Update(model);
                if (res)
                {
                    SetAlert("Cập nhật sản phẩm thành công", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {

                    SetAlert("Cập nhật sản phẩm không thành công", "error");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ProductDAO().Delete(id);
            return RedirectToAction("Index");
        }
    }
}