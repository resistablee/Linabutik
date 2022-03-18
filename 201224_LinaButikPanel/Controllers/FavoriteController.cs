using _201224_LinaButikPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _201224_LinaButikPanel.Controllers
{
    public class FavoriteController : Controller
    {
        // GET: Favorites
        Context model = new Context();
        public ActionResult Index()
        {
            if (Session["cId"] != null)
            {
                int cId = Convert.ToInt32(Session["cId"].ToString());
                List<Favorites> data = model.Favorite.Where(x => x.CustomerID == cId).ToList();
                return View(data);
            }
            else
            {
                return RedirectToAction("CustomerLogin", "Verification");
            }
        }
    }
}