using Agile09.Common;
using Agile09.DAO;
using Agile09.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agile09.Areas.Admin.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Admin/Manager
        public ActionResult Index()
        {
            var dao = new AdminDAO();
            var model = dao.ListAllPaging();
            return View(model.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Agile09.EF.Admin manager)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDAO();
                var encrypterMD5 = Encrypter.MD5Hash(manager.Password);
                manager.Password = encrypterMD5;
                bool CheckUserName = dao.CheckUserName(manager.UserName);
                bool CheckEmail = dao.CheckEmail(manager.Email);
                if (CheckUserName)
                {
                    SetAlert("Tên người quản lý đã tồn tại", "error");
                    return RedirectToAction("Create", "Manager");
                }
                else if (CheckEmail)
                {
                    SetAlert("Email người quản lý đã tồn tại", "error");
                    return RedirectToAction("Create", "Manager");
                }
                else if (!CheckUserName && !CheckEmail)
                {

                    dao.Insert(manager);
                    SetAlert("Đăng kí quản lý thành công", "success");
                    return RedirectToAction("Create", "Manager");
                }
            }
            return View("Index", "Login");
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
        public ActionResult Edit(int id)
        {
            var manager = new AdminDAO();
            var model = manager.ViewDetail(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Agile09.EF.Admin manager)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDAO();
                if (!string.IsNullOrEmpty(manager.Password))
                {
                    var encrypterMD5 = Encrypter.MD5Hash(manager.Password);
                    manager.Password = encrypterMD5;
                }
                bool res = dao.Update(manager);
                if (res)
                {
                    SetAlert("Cập nhật quản lý thành công", "success");
                    return RedirectToAction("Index", "Manager");
                }
                else
                {

                    SetAlert("Cập nhật quản lý không thành công", "error");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new AdminDAO().Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult ChangeStatus(long id)
        {
            var res = new AdminDAO().ChangeStatus(id);
            return Json(new { status = res });
        }
    }
}