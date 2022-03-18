using _201224_LinaButikPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace _201224_LinaButikPanel.Controllers
{
    [Authorize(Roles ="1")] //Sadece adminin giriş yapabilmesi için
    public class OperationController : Controller
    {
        // GET: Operation
        Context model = new Context();
        public ActionResult List()
        {
            List<Operations> data = model.Operation.ToList();
            return View(data);
        }

        //Bu olay trigger ile yapılacak
        public static int Add(Int16 _OperationTypeID, Int16 _PersonTypeID)
        {
            using (Context model= new Context())
            {
                using (Operations op = new Operations())
                {
                    op.OperationTypeID = _OperationTypeID;
                    op.PersonTypeID = _PersonTypeID;
                    op.Person = "admin";
                    op.Hostname = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
                    op.GMT = DateTime.Now;
                    model.Operation.Add(op);
                    return model.SaveChanges();
                }
            }
        }
    }
}