using Agile09.Common;
using Agile09.DAO;
using Agile09.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agile09.Controllers;

namespace Agile09.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var encrypterMD5 = Encrypter.MD5Hash(user.Password);
                user.Password = encrypterMD5;
                bool CheckUserName = dao.CheckUserName(user.UserName);
                bool CheckEmail = dao.CheckEmail(user.Email);
                if (CheckUserName)
                {
                    SetAlert("Tên người dùng đã tồn tại", "error");
                    return RedirectToAction("Create", "User");
                }
                else if (CheckEmail)
                {
                    SetAlert("Email người dùng đã tồn tại", "error");
                    return RedirectToAction("Create", "User");
                }
                else if (!CheckUserName && !CheckEmail)
                {

                    dao.Insert(user);
                    SetAlert("Đăng kí thành viên thành công", "success");
                    return RedirectToAction("Create", "User");
                }
            }
            return View("Index", "Login");
        }
        public void SetAlert(string mess, string type)
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
            var user = new UserDAO();
            var model = user.ViewDetail(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                if (!string.IsNullOrEmpty(user.Password))
                {
                    var encrypterMD5 = Encrypter.MD5Hash(user.Password);
                    user.Password = encrypterMD5;
                }
                bool res = dao.Update(user);
                if (res)
                {
                    //SetAlert("Cập nhật người dùng thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {

                    ModelState.AddModelError("", "Cập nhật người dùng không thành công");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDAO().Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var res = new UserDAO().ChangeStatus(id);
            return Json(new
            { status = res });
        }
    }
}