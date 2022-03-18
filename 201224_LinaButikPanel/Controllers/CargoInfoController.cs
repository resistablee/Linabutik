using _201224_LinaButikPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _201224_LinaButikPanel.Controllers
{
    public class CargoInfoController : Controller
    {
        // GET: CargoInfo
        Context model = new Context();

        [HttpGet]
        public ActionResult Add(int oId)
        {
            Orders data = model.Order.Where(x => x.Id == oId).FirstOrDefault();
            CargoInfo ci = new CargoInfo();
            ci.OrderID = oId;
            ci.CustomerID = data.CustomerID;
            ci.CargoCompanyID = 75;
            ci.AddressID = data.AddressID;
            ViewBag.CargoCompaines = Lists.GetCargoCompanies();
            return PartialView("PV_Add", ci);
        }

        public PartialViewResult PV_Add()
        {
            ViewBag.CargoCompaines = Lists.GetCargoCompanies();
            return PartialView();
        }


        [HttpPost]
        public JsonResult Add(CargoInfo ci)
        {
            try
            {
                if (model.CargoInfo.Where(x => x.OrderID == ci.OrderID).Count() < 1)
                {
                    ci.GMT = DateTime.Now;
                    model.CargoInfo.Add(ci);
                    model.SaveChanges();
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}