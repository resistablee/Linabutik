using _201224_LinaButikPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace _201224_LinaButikPanel.Controllers
{
    public class OrderController : Controller
    {
        // GET: ORder
        Context model = new Context();
        public ActionResult List()
        {
            List<Orders> data = model.Order.ToList();
            return View(data);
        }

        [HttpPost]
        public JsonResult Add(Orders ord)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //int cId = Convert.ToInt32(Session["cId"].ToString());//cmail tutuyor
                    string cmail = Session["cmail"].ToString();
                    int cid = (from x in model.Customer.Where(x => x.Mail == cmail) select x.Id).FirstOrDefault();
                    //Customers cus = model.Customer.Where(x => x.Mail == cmail).FirstOrDefault();
                    List<Basket> data = model.Basket.Where(x => x.CustomerID == cid).ToList();

                    ord.PaymentTypeID = 40; //Parametre olarak view'den çekilecek
                    ord.AddressID = 3; //Parametre olarak view'den çekilecek
                    ord.OrderStatusID = 32; //Sipariş alındı yapıyor
                    ord.CardTypeID = 100;
                    ord.GMT = DateTime.Now;
                    ord.CustomerID = cid;
                    ord.Total = model.Basket.Where(x => x.CustomerID == cid).Sum(x => x.Total);
                    ord.Hostname = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
                    model.Order.Add(ord);
                    model.SaveChanges();
                    using (OrderDetails od = new OrderDetails())
                    {
                        od.OrderID = ord.Id;
                        foreach (var item in data)
                        {
                            od.OrderStatusID = 32;
                            od.ProductID = item.ProductID;
                            od.UnitPrice = item.Product.Price;
                            od.Piece = item.Piece;
                            od.Total = item.Product.Price * item.Piece;
                            model.OrderDetail.Add(od);
                            model.Basket.Remove(item);
                            model.SaveChanges();
                        }
                        foreach (var item in data)
                        {
                            model.Basket.Remove(item);
                            model.SaveChanges();
                        }
                    }

                    return Json(1, JsonRequestBehavior.AllowGet); //Sipariş alındı
                }
                return Json(2, JsonRequestBehavior.AllowGet); //Girişe izin verildi
            }
            catch (Exception)
            {
                return Json(3, JsonRequestBehavior.AllowGet); //Girişe izin verildi
            }

        }
    }
}