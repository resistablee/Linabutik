using _201224_LinaButikPanel.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace _201224_LinaButikPanel.Controllers
{

    public class ProductController : Controller
    {
        // GET: Product

        Context model = new Context();
        public ActionResult List()
        {
            List<Products> data = model.Product.Where(x => x.Status == true).ToList();



            return View(data);
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Categories = Lists.GetProductCategory();
            ViewBag.Colors = Lists.GetColors();
            ViewBag.Size = Lists.GetSizes();
            ViewBag.Brands = Lists.GetBrands();
            return View();
        }

        [HttpPost]
        public JsonResult Add(MM_OrderDetails entity)
        {
            //Ürün resmini trigger ile alıyor
            try
            {
                if (ModelState.IsValid)
                {
                    entity.product.Status = true;
                    entity.product.ProductCode = Lists.CreateProductCode(entity.product);
                    foreach (var item in entity.product.Sizes)
                    {
                        //entity.product.SizeID = item;
                        model.Product.Add(entity.product);
                        model.SaveChanges();
                    }
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    ViewBag.Categories = Lists.GetProductCategory();
                    ViewBag.Colors = Lists.GetColors();
                    ViewBag.Size = Lists.GetSizes();
                    ViewBag.Brands = Lists.GetBrands();
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Update(int pId)
        {
            Products data = model.Product.Find(pId);
            ViewBag.Categories = Lists.GetProductCategory();
            ViewBag.Colors = Lists.GetColors();
            ViewBag.Sizes = Lists.GetSizes();
            ViewBag.Brands = Lists.GetBrands();
            return PartialView("PV_ProductUpdate", data);
        }

        public PartialViewResult PV_ProductUpdate()
        {
            return PartialView();
        }








        [HttpPost]
        public ActionResult Update(Products entity)
        {
            if (ModelState.IsValid)
            {
                Products data = model.Product.Find(entity.Id);
                data.ProductCode = entity.ProductCode;
                data.CategoryID = entity.CategoryID;
                data.Name = entity.Name;
                //data.BrandID = entity.BrandID;
                data.ColorID = entity.ColorID;
                data.SizeID = entity.SizeID;
                data.Price = entity.Price;
                data.Description = entity.Description;
                data.SaleStatus = entity.SaleStatus;
                model.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                Products data = model.Product.Find(entity.Id);
                ViewBag.Categories = Lists.GetProductCategory();
                ViewBag.Colors = Lists.GetColors();
                ViewBag.Sizes = Lists.GetSizes();
                ViewBag.Brands = Lists.GetBrands();
                return PartialView("PV_ProductUpdate", data);
            }
        }

        [ChildActionOnly]
        public ActionResult Delete(int pId)
        {
            Products data = model.Product.Find(pId);
            data.Status = false;
            model.SaveChanges();
            return RedirectToAction("List");
        }
    }
}