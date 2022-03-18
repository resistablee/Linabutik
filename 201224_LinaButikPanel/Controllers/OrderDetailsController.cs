using _201224_LinaButikPanel.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace _201224_LinaButikPanel.Controllers
{
    public class OrderDetailsController : Controller
    {
        // GET: Order
        Context model = new Context();
        public ActionResult Detail(int oNO)
        {
            List<OrderDetails> data = model.OrderDetail.Where(x => x.OrderID == oNO).ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Update(int oId)
        {
            OrderDetails data = model.OrderDetail.Find(oId);
            ViewBag.oStatus = Lists.GetOrderStatus();
            return View(data);
        }

        [HttpPost]
        public ActionResult Update(OrderDetails entity)
        {
            if (ModelState.IsValid)
            {
                OrderDetails data = model.OrderDetail.Find(entity.Id);
                data.OrderStatusID = entity.OrderStatusID;
                data.Cargo.TruckNumber = entity.Cargo.TruckNumber;
                model.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                OrderDetails data = model.OrderDetail.Find(entity.Id);
                ViewBag.oStatus = Lists.GetOrderStatus();
                return View(data);
            }
        }
    }
}