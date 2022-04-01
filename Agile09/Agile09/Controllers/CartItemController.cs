using Agile09.Common;
using Agile09.DAO;
using Agile09.EF;
using Agile09.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        // Thêm item vào giỏ hàng
        public ActionResult AddItem(long productID, int quantity)
        {
            var product = new ProductDAO().ViewDetail(productID);
            var cart = Session[CommonConstants.CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.ID == productID))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ID == productID)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    // Tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);

                }
                // Gán vào sesstion
                Session[CommonConstants.CartSession] = list;
            }
            else
            {
                // Tạo mới đối tượng cart item
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                // Gán vào sesstion
                list.Add(item);
                Session[CommonConstants.CartSession] = list;
            }
            return RedirectToAction("Index");
        }
        // Cập nhật giỏ hàng
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CommonConstants.CartSession];
            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ID == item.Product.ID);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CommonConstants.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        // Xoá tất cả trong giỏ hàng
        public JsonResult DeleteAll()
        {
            Session[CommonConstants.CartSession] = null;
            return Json(new
            {
                status = true
            });
        }
        // Xoá 1 món trong giỏ hàng
        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CommonConstants.CartSession];
            sessionCart.RemoveAll(x => x.Product.ID == id);
            Session[CommonConstants.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        //Thanh toán
        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult Payment(string shipName, string mobile, string address, string email)
        {
            var order = new OrderProduct();
            order.CreatedDate = DateTime.Now;
            order.ShipAddress = address;
            order.ShipMobile = mobile;
            order.ShipName = shipName;
            order.ShipEmail = email;

            try
            {
                var id = new OrderDAO().Insert(order);
                var cart = (List<CartItem>)Session[CommonConstants.CartSession];
                var detailDAO = new OrderDetailDAO();
                decimal total = 0;

                //tạo thống kê
                //bool isEnough = true;

                foreach (var item in cart)
                {
                    var orderDetail = new OrderDetail();
                    orderDetail.ProductID = item.Product.ID;
                    orderDetail.OrderID = id;
                    orderDetail.Price = item.Product.Price;
                    orderDetail.Quantity = item.Quantity;
                    detailDAO.Insert(orderDetail);

                    total += (item.Product.Price.GetValueOrDefault(0) * item.Quantity);
                    //isEnough = new SalesProduct().SellProduct(item.Product.ID, item.Quantity);
                    //break;
                }
            }
            catch (Exception er)
            {
                //ghi log
                return Redirect("/loi-thanh-toan");
            }
            Session[CommonConstants.CartSession] = null;
            return Redirect("/hoan-thanh");
        }
        public ActionResult Success()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
    }
}