using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
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
        WebNhaHangDbContext myDb = new WebNhaHangDbContext();
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

        public ActionResult HistoryOrder(int userId, string msg)
        {
            ViewBag.Msg = msg;
            ViewBag.HistoryOrder = orderRepository.GetOrdersByUserId(userId);
            return View();
        }

        [HttpPost]
        public ActionResult Order(Order order, FormCollection form)
        {
            Session.Add("ORDER", order);
            int payment = Int32.Parse(form["payment"]);
            User user = (User)Session["USER"];
            List<CartItem> cart = (List<CartItem>)Session["Cart"];
            int total = 0;

            foreach (CartItem item in cart)
            {
                total += item.Price * item.Quantity;
            }
          
            OrderDetail orderDetail = new OrderDetail();
            if(payment == 1)
            { 
                order.Created_at = DateTime.Now.ToString();
                order.Amount = total;
                order.UserId = user.UserId;
                orderRepository.AddOrder(order);
                foreach (CartItem item in cart)
                {
                    orderDetail.FoodId = item.FoodId;
                    orderDetail.OrderId = order.OrderId;
                    orderDetail.Quantity = item.Quantity;
                    detailRepository.AddOrderDetail(orderDetail);
                }
                Session.Remove("Cart");
                return RedirectToAction("HistoryOrder", "Order", new {userId = user.UserId, msg = "1" });
            }
            else
            {
                string url = "https://localhost:44306/Order/ReturnUrl/";
                //request params need to request to MoMo system
                string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
                string partnerCode = "MOMOOJOI20210710";
                string accessKey = "iPXneGmrJH0G8FOP";
                string serectkey = "sFcbSGRSJjwGxwhhcEktCHWYUuTuPNDB";
                string orderInfo = "Thanh toán cho phòng tại web";
                string returnUrl = url;
                string notifyurl = "http://ba1adf48beba.ngrok.io/Home/SavePayment"; //lưu ý: notifyurl không được sử dụng localhost, có thể sử dụng ngrok để public localhost trong quá trình test

                string amount = total.ToString();
                string orderid = DateTime.Now.Ticks.ToString();
                string requestId = DateTime.Now.Ticks.ToString();
                string extraData = "";

                //Before sign HMAC SHA256 signature
                string rawHash = "partnerCode=" +
                    partnerCode + "&accessKey=" +
                    accessKey + "&requestId=" +
                    requestId + "&amount=" +
                    amount + "&orderId=" +
                    orderid + "&orderInfo=" +
                    orderInfo + "&returnUrl=" +
                    returnUrl + "&notifyUrl=" +
                    notifyurl + "&extraData=" +
                    extraData;

                //sign signature SHA256
                string signature = signSHA256(rawHash, serectkey);

                //build body json request
                JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "accessKey", accessKey },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderid },
                { "orderInfo", orderInfo },
                { "returnUrl", returnUrl },
                { "notifyUrl", notifyurl },
                { "extraData", extraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }

            };

                string responseFromMomo = sendPaymentRequest(endpoint, message.ToString());

                JObject jmessage = JObject.Parse(responseFromMomo);
                return Redirect(jmessage.GetValue("payUrl").ToString());
            }                  
        }

        public ActionResult ReturnUrl()
        {
            Order order = (Order)Session["ORDER"];
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
            order.IsPayment = 1;
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
            Session.Remove("ORDER");
            return RedirectToAction("HistoryOrder", "Order", new { userId = user.UserId, msg = "1" });
        }

        //Khi thanh toán xong ở cổng thanh toán Momo, Momo sẽ trả về một số thông tin, trong đó có errorCode để check thông tin thanh toán
        //errorCode = 0 : thanh toán thành công (Request.QueryString["errorCode"])
        //Tham khảo bảng mã lỗi tại: https://developers.momo.vn/#/docs/aio/?id=b%e1%ba%a3ng-m%c3%a3-l%e1%bb%97i
        public ActionResult ConfirmPaymentClient()
        {
            //hiển thị thông báo cho người dùng
            return View();
        }

        [HttpPost]
        public void SavePayment()
        {
            //cập nhật dữ liệu vào db
        }
        public string getHash(string partnerCode, string merchantRefId,
          string amount, string paymentCode, string storeId, string storeName, string publicKeyXML)
        {
            string json = "{\"partnerCode\":\"" +
                partnerCode + "\",\"partnerRefId\":\"" +
                merchantRefId + "\",\"amount\":" +
                amount + ",\"paymentCode\":\"" +
                paymentCode + "\",\"storeId\":\"" +
                storeId + "\",\"storeName\":\"" +
                storeName + "\"}";

            byte[] data = Encoding.UTF8.GetBytes(json);
            string result = null;
            using (var rsa = new RSACryptoServiceProvider(4096)) //KeySize
            {
                try
                {
                    // MoMo's public key has format PEM.
                    // You must convert it to XML format. Recommend tool: https://superdry.apphb.com/tools/online-rsa-key-converter
                    rsa.FromXmlString(publicKeyXML);
                    var encryptedData = rsa.Encrypt(data, false);
                    var base64Encrypted = Convert.ToBase64String(encryptedData);
                    result = base64Encrypted;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }

            }

            return result;

        }
        public string buildQueryHash(string partnerCode, string merchantRefId,
            string requestid, string publicKey)
        {
            string json = "{\"partnerCode\":\"" +
                partnerCode + "\",\"partnerRefId\":\"" +
                merchantRefId + "\",\"requestId\":\"" +
                requestid + "\"}";

            byte[] data = Encoding.UTF8.GetBytes(json);
            string result = null;
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                try
                {
                    // client encrypting data with public key issued by server
                    rsa.FromXmlString(publicKey);
                    var encryptedData = rsa.Encrypt(data, false);
                    var base64Encrypted = Convert.ToBase64String(encryptedData);
                    result = base64Encrypted;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }

            }

            return result;

        }

        public string buildRefundHash(string partnerCode, string merchantRefId,
            string momoTranId, long amount, string description, string publicKey)
        {
            string json = "{\"partnerCode\":\"" +
                partnerCode + "\",\"partnerRefId\":\"" +
                merchantRefId + "\",\"momoTransId\":\"" +
                momoTranId + "\",\"amount\":" +
                amount + ",\"description\":\"" +
                description + "\"}";

            byte[] data = Encoding.UTF8.GetBytes(json);
            string result = null;
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                try
                {
                    // client encrypting data with public key issued by server
                    rsa.FromXmlString(publicKey);
                    var encryptedData = rsa.Encrypt(data, false);
                    var base64Encrypted = Convert.ToBase64String(encryptedData);
                    result = base64Encrypted;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }

            }

            return result;

        }
        public string signSHA256(string message, string key)
        {
            byte[] keyByte = Encoding.UTF8.GetBytes(key);
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                string hex = BitConverter.ToString(hashmessage);
                hex = hex.Replace("-", "").ToLower();
                return hex;

            }
        }

        public static string sendPaymentRequest(string endpoint, string postJsonString)
        {

            try
            {
                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(endpoint);

                var postData = postJsonString;

                var data = Encoding.UTF8.GetBytes(postData);

                httpWReq.ProtocolVersion = HttpVersion.Version11;
                httpWReq.Method = "POST";
                httpWReq.ContentType = "application/json";

                httpWReq.ContentLength = data.Length;
                httpWReq.ReadWriteTimeout = 30000;
                httpWReq.Timeout = 15000;
                Stream stream = httpWReq.GetRequestStream();
                stream.Write(data, 0, data.Length);
                stream.Close();

                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();

                string jsonresponse = "";

                using (var reader = new StreamReader(response.GetResponseStream()))
                {

                    string temp = null;
                    while ((temp = reader.ReadLine()) != null)
                    {
                        jsonresponse += temp;
                    }
                }


                //todo parse it
                return jsonresponse;
                //return new MomoResponse(mtid, jsonresponse);

            }
            catch (WebException e)
            {
                return e.Message;
            }
        }
    }
}