using _201224_LinaButikPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _201224_LinaButikPanel.Controllers
{
    public class RemoteControlController : Controller
    {
        // GET: RemoteControl
        Context model = new Context();
        public JsonResult IsManagerUserNameAvailable(string Username)
        {
            var user = model.Manager.Where(x => x.Username == Username);
            if (user != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsManagerMailAvailable(string mail)
        {
            var user = model.Manager.Where(x => x.Mail == mail);
            if (user != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsCustomerMailAvailable(string Mail)
        {
            Customers user = model.Customer.Where(x => x.Mail == Mail).FirstOrDefault();
            if (user != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}