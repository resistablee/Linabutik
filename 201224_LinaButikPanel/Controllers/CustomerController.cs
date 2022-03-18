using _201224_LinaButikPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace _201224_LinaButikPanel.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        Context model = new Context();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Liked()
        {
            return PartialView();
        }


        [Authorize]
        public ActionResult List()
        {
            List<Customers> data = model.Customer.ToList();
            return View(data);
        }

        [HttpPost]
        public JsonResult Add(Customers entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.Status = true;
                    model.Customer.Add(entity);
                    model.SaveChanges();
                    Session["cmail"] = entity.Mail.ToString();
                    return Json(1, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    ViewBag.Genders = Lists.GetGenders();
                    return Json(2, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json(3, JsonRequestBehavior.AllowGet);
            }

        }


        public ActionResult CustomerOrders(int cId)
        {
            List<Orders> data = model.Order.Where(x => x.CustomerID == cId).ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Update(int cId)
        {
            Customers data = model.Customer.Find(cId);
            return View(data);
        }

        [HttpPost]
        public ActionResult Update(Customers entity)
        {
            if (ModelState.IsValid)
            {
                Customers data = model.Customer.Find(entity.Id);
                data.NameSurname = entity.NameSurname;
                data.Password = entity.Password;
                data.TelephoneNumber = entity.TelephoneNumber;
                model.SaveChanges();
                return RedirectToAction("List", "Customer");
            }
            else
            {
                Customers data = model.Customer.Find(entity.Id);
                return View(data);
            }
        }
    }
}