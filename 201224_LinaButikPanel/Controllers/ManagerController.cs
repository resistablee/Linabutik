using _201224_LinaButikPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _201224_LinaButikPanel.Controllers
{
    [Authorize]
    public class ManagerController : Controller
    {
        // GET: Manager
        Context model = new Context();
        public ActionResult List()
        {
            if (Session["ManagerId"] != null)
            {
                int mId = Convert.ToInt32(Session["ManagerId"].ToString());
                var info = model.Manager.Where(x => x.Id == mId).FirstOrDefault();
                if (info.AuthorityID == 64) //Sadece 1. derece yetkili kişiler yöneticileri görebilecek
                {
                    List<Managers> data = model.Manager.ToList();
                    return View(data);
                }
                else
                {
                    return RedirectToAction("Index", "Panel");
                }
            }
            else
            {
                return RedirectToAction("AdminLogin", "Verification");
            }
        }
    }
}