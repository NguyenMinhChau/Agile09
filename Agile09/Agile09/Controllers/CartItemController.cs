using Agile09.Common;
using Agile09.DAO;
using Agile09.EF;
using Agile09.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Agile09.Controllers
{
    public class CartItemController : Controller
    {
        // GET: CartItem
        public ActionResult Index()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
    }
}