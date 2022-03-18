using _201224_LinaButikPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;

namespace _201224_LinaButikPanel.Controllers
{
    public class ProductPropertyController : Controller
    {
        // GET: ProductProperty
        Context model = new Context();
        public PartialViewResult CategoryList()
        {
            List<Features> data = model.Feature.Where(x => x.FeatureTypeID == 1).ToList();
            return PartialView(data);
        }

        public PartialViewResult ColorList()
        {
            List<Features> data = model.Feature.Where(x => x.FeatureTypeID == 2).ToList();
            return PartialView(data);
        }

        public PartialViewResult SizeList()
        {
            List<Features> data = model.Feature.Where(x => x.FeatureTypeID == 3).ToList();
            return PartialView(data);
        }

        //Manuel sayfalama
        public ActionResult Categories(string cName, int page = 1)
        {
            IPagedList<Features> data = model.Feature.Where(x => x.FeatureTypeID == 1).ToList().ToPagedList(page, 5);
            if (!string.IsNullOrEmpty(cName))
            {
                data = data.Where(x => x.Property.Contains(cName)).ToList().ToPagedList(page, 5);
            }
            return View(data);
        }

        [HttpGet]
        public ActionResult CategoryUpdate(int cId)
        {
            Features data = model.Feature.Find(cId);
            return PartialView("PV_CategoryUpdate", data);
        }

        [HttpPost]
        public ActionResult CategoryUpdate(Features entity)
        {
            if (ModelState.IsValid)
            {
                Features data = model.Feature.Find(entity.Id);
                data.Property = entity.Property;
                model.SaveChanges();
                return RedirectToAction("Categories", "ProductProperty");
            }
            else
            {
                Features data = model.Feature.Find(entity.Id);
                return PartialView("PV_CategoryUpdate", data);
            }
        }


        public PartialViewResult PV_CategoryUpdate()
        {
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult PV_CategoryAdd()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult CategoryAdd(Features entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.FeatureTypeID = 1;
                    entity.Des = entity.Property.Substring(0,3).ToUpper();
                    model.Feature.Add(entity);
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


        public ActionResult AddImage(ProductImages pi)
        {
            return View();
        }

        public JsonResult CategoryDelete(int cId)
        {
            try
            {
                Features data = model.Feature.Find(cId);
                model.Feature.Remove(data);
                model.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}