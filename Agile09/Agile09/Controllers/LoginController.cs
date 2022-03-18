using Agile09.Common;
using Agile09.Models;
using Agile09.DAO;
using Agile09.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
//using Facebook;
//using CKFinder.Connector;
using System.Configuration;

namespace Agile09.Controllers
{
    public class LoginController : Controller
    {
        //THAM KHẢO============================================
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }
        private Uri RedirectUriGG
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("GoogleCallback");
                return uriBuilder.Uri;
            }
        }

        //====================================================
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoginUser(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var result = dao.Login(model.UserName, Encrypter.MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = dao.GetByID(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;

                    Session.Add(Constant.USER_SECTION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản bị khóa");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Đăng nhập thất bại. Vui lòng kiểm tra lại");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập thất bại. Vui lòng kiểm tra lại");
                }
            }
            return View("Index");

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }

        //THAM KHẢO========================================
        
        

        
    }
}