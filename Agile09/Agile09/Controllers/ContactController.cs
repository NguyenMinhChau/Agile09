using Agile09.DAO;
using Agile09.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agile09.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            var model = new ContactDAO().GetActiveContext();
            return View(model);
        }
        [HttpPost]
        public JsonResult Send(string name, string phone, string email, string content, string address)
        {
            var feedback = new Feedback();
            feedback.Name = name;
            feedback.Phone = phone;
            feedback.Email = email;
            feedback.Content = content;
            feedback.Address = address;
            feedback.CreatedDate = DateTime.Now;

            var id = new ContactDAO().InsertFeedBack(feedback);
            if (id > 0&& feedback.Name !=""&& feedback.Phone!=""&& feedback.Email!=""&&feedback.Content !=""&& feedback.Address!="")
            {
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }
    }
}