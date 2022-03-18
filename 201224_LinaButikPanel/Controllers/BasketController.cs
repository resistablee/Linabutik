using _201224_LinaButikPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _201224_LinaButikPanel.Controllers
{
    public class BasketController : Controller
    {
        // GET: Basket
        Context model = new Context();
        public ActionResult Index()
        {
            //Session'ın içi boş değilse kullanıcı ürünü sepetine ekleyebiliyor. cmail isimli session verification controller'ında dolduruluyor.
            if (Session["cmail"] != null)
            {

                string cmail = Session["cmail"].ToString();
                Customers cus = model.Customer.Where(x => x.Mail == cmail).FirstOrDefault();
                List<Basket> data = model.Basket.Where(x => x.CustomerID == cus.Id).ToList();
                return View(data);
            }
            //Session'ın içi boşsa eğer kullanıcıyı login ekranına yönlendiriyoruz..
            else
            {
                return RedirectToAction("CustomerLogin", "Verification");
            }
        }


        [HttpPost]//Jsonresult döndürecek. Ürün sepete eklenince sağ üstte eklendi diye uyarı verecek.
        public ActionResult AddToCart(MM_OrderDetails entity, Int16 piece)
        {
            //Session'ın içi boş değilse kullanıcı .
            if (Session["cmail"] != null)
            {
                using (Basket bsk = new Basket())
                {
                    string cmail = Session["cmail"].ToString();
                    Customers cus = model.Customer.Where(x => x.Mail == cmail).FirstOrDefault();

                    bsk.CustomerID = cus.Id;
                    bsk.ProductID = entity.product.Id;
                    bsk.Piece = piece;
                    bsk.Total = entity.product.Price * piece;
                    model.Basket.Add(bsk);
                }
                model.SaveChanges();
                return RedirectToAction("UrunList", "Sale");
            }
            else
            {
                return RedirectToAction("CustomerLogin", "Verification");
            }
        }
    }
}