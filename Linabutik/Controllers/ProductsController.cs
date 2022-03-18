using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _201224_LinaButikPanel.Models;

namespace Linabutik.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        Context model = new Context();
        public ActionResult Index(string Kategori)
        {
            List<Products> data;
            if (Kategori != null)
            {
                data = model.Product.Where(x => x.Status == true && x.Category.Property == Kategori).Distinct().ToList();
                ViewBag.CategoryName = Kategori;
            }
            else
            {
                data = model.Product.Where(x => x.Status == true).Distinct().ToList();
            }
            return View(data);
        }
    }
}