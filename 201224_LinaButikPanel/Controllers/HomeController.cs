using _201224_LinaButikPanel.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _201224_LinaButikPanel.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: Home
        Context model = new Context();
        //public ActionResult Index(string Kategori)
        //{
        //    List<Products> data;
        //    if (Kategori != null)
        //    {
        //        data = model.Product.Where(x => x.Status == true && x.Category.Property == Kategori).Distinct().ToList();
        //        ViewBag.CategoryName = Kategori;
        //    }
        //    else
        //    {
        //        data = model.Product.Where(x => x.Status == true).Distinct().ToList();
        //    }
        //    return View(data);
        //}

        public ActionResult Index(string Kategori, int p = 1)
        {
            IPagedList<Products> data;

            if (Kategori != null)
            {
                data = model.Product.Where(x => x.Status == true && x.Category.Property == Kategori).Distinct().ToList().ToPagedList(p, 10);
                ViewBag.CategoryName = Kategori;
            }
            else
            {
                data = model.Product.Where(x => x.Status == true).Distinct().ToList().ToPagedList(p, 10);
            }
            return View(data);
        }
    }
}