using _201224_LinaButikPanel.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace _201224_LinaButikPanel.Controllers
{
    [AllowAnonymous]
    public class SaleController : Controller
    {
        // GET: Sale
        Context model = new Context();


        [AllowAnonymous]
        public ActionResult UrunList(string Kategori)
        {
            List<Products> data;
            //if (Kategori != null)
            //{
            //    data = model.Product.Where(x => x.Status == true && x.Category.Property == Kategori).Distinct().ToList();
            //    ViewBag.CategoryName = Kategori;
            //}
            //else
            //{
            //    data = model.Product.Where(x => x.Status == true).Distinct().ToList();
            //}

            if (Kategori != null)
            {
                var query = model.Product.Where(x => x.Status == true && x.Category.Property == Kategori).Select(a => new
                {
                    Id = a.Id,
                    Name = a.Name,
                    Brand = a.Brand,
                    Price = a.Price,
                    ProductCode = a.ProductCode,
                }).Distinct();

                data = query.ToList().Select(r => new Products
                {
                    Id = r.Id,
                    Name = r.Name,
                    Brand = r.Brand,
                    Price = r.Price,
                    ProductCode = r.ProductCode,
                }).ToList();
                ViewBag.CategoryName = Kategori;
            }
            else
            {
                var query = model.Product.Where(x => x.Status == true).Select(a => new
                {
                    Id = a.Id,
                    Name = a.Name.Distinct().ToString(),
                    Brand = a.Brand,
                    Price = a.Price,
                    ProductCode = a.ProductCode
                }).Distinct();

                data = query.ToList().Select(r => new Products
                {
                    Id = r.Id,
                    Name = r.Name,
                    Brand = r.Brand,
                    Price = r.Price,
                    ProductCode = r.ProductCode,
                }).ToList();
            }
            return View(data);
        }

        [AllowAnonymous]
        public ActionResult ProductDetail(string pCode, int? cId)
        {
            if (cId is null)
            {
                cId = model.Product.Where(x => x.ProductCode == pCode).Select(x => x.ColorID).FirstOrDefault();
            }
            using (MM_OrderDetails data = new MM_OrderDetails())
            {
                ViewBag.Customers = Lists.GetCustomers();
                int pId = model.Product.Where(x => x.ProductCode == pCode).Select(x => x.Id).FirstOrDefault();
                data.product = model.Product.Where(x => x.ProductCode == pCode && x.ColorID == cId).FirstOrDefault();
                data.colors = Lists.GetProductColors(pCode);
                data.sizes = Lists.GetProductSize(pCode, cId);
                data.pImage = model.ProductImage.Where(x => x.ProductID == pId).FirstOrDefault();
                return View(data);
            }
        }

        [HttpGet]
        public ActionResult Checkout()
        {
            string cmail = Session["cmail"].ToString();
            if (cmail != null)
            {
                Customers cus = model.Customer.Where(x => x.Mail == cmail).FirstOrDefault();
                ViewBag.total = (from x in model.Basket.Where(x => x.CustomerID == cus.Id) select x.Total).Sum();
                return View();
            }
            else
            {
                return RedirectToAction("CustomerLogin", "Verification");
            }
        }
    }
}