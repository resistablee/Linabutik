using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web.Mvc;
using _201224_LinaButikPanel.Models;
using System.Web;

namespace _201224_LinaButikPanel.Controllers
{
    [AllowAnonymous]
    public class VerificationController : Controller
    {
        // GET: Login
        Context model = new Context();
        [HttpGet]
        public ActionResult CustomerLogin()
        {
            //Eğer kullanıcı bilgilerinin çerezi var ise kullanıcıya login ekranına göstermeden direk kullanıcıyı index sayfasına yönlendiriyor.
            if (Request.Cookies["userinfo"] != null)
            {
                HttpCookie savedcookie = Request.Cookies["userinfo"];
                Session["cmail"] = savedcookie.Values["cmail"];
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public JsonResult CustomerLogin(CustomerAuthentication entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var info = model.Customer.FirstOrDefault(x => x.Mail == entity.Mail && x.Password == entity.Password);
                    if (info != null)
                    {
                        if (entity.remember) //Beni hatırla checkbox'ı işaretliyse cookie ekliyor.
                        {
                            HttpCookie cookie = new HttpCookie("userinfo");
                            cookie.Values.Add("cmail", info.Mail.ToString());
                            cookie.Values.Add("cpass", info.Password.ToString());
                            cookie.Expires = DateTime.Now.AddDays(1); //Cookienin yaşam süresine 1 gün ekliyor.
                            Response.Cookies.Add(cookie);
                        }
                        else
                        {
                            Session["cmail"] = info.Mail.ToString();
                        }
                        return Json(1, JsonRequestBehavior.AllowGet); //Girişe izin verildi
                    }
                    else
                    {
                        return Json(2, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(3, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json(4, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AdminLogin(AdminAuthentication entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Yönetici bilgisi var mı yok mu kontrol ediyor.
                    var info = model.Manager.FirstOrDefault(x => x.Username == entity.Username && x.Password == entity.Password);
                    if (info != null)
                    {
                        FormsAuthentication.SetAuthCookie(info.Id.ToString(), false);
                        Session["ManagerId"] = info.Id.ToString();
                        return Json(1, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(2, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(3, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json(4, JsonRequestBehavior.AllowGet);
            }

        }


        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.Genders = Lists.GetGenders();
            return View();
        }

        [HttpGet]//Post metodu Customer/Add adresine gidiyor
        public ActionResult ForgotPass()
        {
            ViewBag.Genders = Lists.GetGenders();
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPass(Customers entity)
        {
            return View();
        }

        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Index", "Panel");
        }
    }
}



/*
 <add name="Context" connectionString="metadata=res://*;provider=System.Data.SqlClient;provider connection string='workstation id=LinaButikPanel.mssql.somee.com;packet size=4096;user id=resistablee_SQLLogin_1;pwd=ds6i7545nv;data source=LinaButikPanel.mssql.somee.com;persist security info=False;initial catalog=LinaButikPanel'" providerName="System.Data.EntityClient" />
 */