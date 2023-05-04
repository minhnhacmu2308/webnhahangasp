using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webnhahangasp.Models;
using webnhahangasp.Repository;

namespace webnhahangasp.Controllers
{
    public class OrderController : Controller
    {
        FoodRepository foodRepository = new FoodRepository();
        OrderRepository orderRepository = new OrderRepository();
        OrderDetailRepository detailRepository = new OrderDetailRepository();
        public ActionResult Index(string msg)
        {
            ViewBag.Msg = msg;
            List<CartItem> cart = (List<CartItem>)Session["Cart"];
            ViewBag.listItems = cart;
            return View(cart);
        }

        // Hành động (action) để thêm sản phẩm vào giỏ hàng
        public ActionResult AddToCart(int foodId)
        {
            Food food = foodRepository.GetFood(foodId);

            if (food != null)
            {
                // Kiểm tra xem giỏ hàng đã tồn tại trong session hay chưa
                if (Session["Cart"] == null)
                {
                    // Nếu giỏ hàng chưa tồn tại, tạo mới một giỏ hàng và thêm sản phẩm vào đó
                    List<CartItem> cart = new List<CartItem>();
                    cart.Add(new CartItem { FoodId = food.FoodId, FoodName = food.Name, Price = food.Price, Quantity = 1 ,Image = food.Image});
                    Session["Cart"] = cart;
                }
                else
                {
                    // Nếu giỏ hàng đã tồn tại, lấy giỏ hàng ra và thêm sản phẩm vào đó
                    List<CartItem> cart = (List<CartItem>)Session["Cart"];
                    bool itemExists = false;

                    foreach (CartItem item in cart)
                    {
                        if (item.FoodId == food.FoodId)
                        {
                            item.Quantity++;
                            itemExists = true;
                            break;
                        }
                    }

                    if (!itemExists)
                    {
                        cart.Add(new CartItem { FoodId = food.FoodId, FoodName = food.Name, Price = food.Price, Quantity = 1, Image = food.Image });
                    }

                    Session["Cart"] = cart;
                }
            }

            return RedirectToAction("Index", "Order", new { msg ="1"});
        }

        public ActionResult RemoveToCart(int foodId)
        {
            List<CartItem> cart = (List<CartItem>)Session["Cart"];
            foreach (CartItem item in cart)
            {
                if (item.FoodId == foodId)
                {
                    cart.Remove(item);
                    break;
                }
            }
            Session["Cart"] = cart;
            return RedirectToAction("Index", "Order", new { msg = "2" });
        }

        [HttpPost]
        public JsonResult ChangeQuantity(int foodId , int quantity)
        {
            List<CartItem> cart = (List<CartItem>)Session["Cart"];
            int total = 0;

            foreach (CartItem item in cart)
            {
                if (item.FoodId == foodId)
                {
                    item.Quantity = quantity;
                }
                total += item.Price * item.Quantity;
            }
            Session["Cart"] = cart;

            return Json(total, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Order(Order order)
        {
            User user = (User)Session["USER"];
            List<CartItem> cart = (List<CartItem>)Session["Cart"];
            int total = 0;

            foreach (CartItem item in cart)
            {
                total += item.Price * item.Quantity;
            }
            order.Created_at = DateTime.Now.ToString();
            order.Amount = total;
            order.UserId = user.UserId;
            orderRepository.AddOrder(order);
            OrderDetail orderDetail = new OrderDetail();
            foreach (CartItem item in cart)
            {
                orderDetail.FoodId = item.FoodId;
                orderDetail.OrderId = order.OrderId;
                orderDetail.Quantity = item.Quantity;
                detailRepository.AddOrderDetail(orderDetail);
            }
            Session.Remove("Cart");
            return RedirectToAction("Index", "Home", new { msg = "2" });
        }
    }
}