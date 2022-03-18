using _201224_LinaButikPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _201224_LinaButikPanel.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        Context model = new Context();
        public ActionResult Index()
        {
            using (MM_Statistics st = new MM_Statistics())
            {
                st.CustomerCount = model.Customer.Distinct().Count();
                st.LastOrder = model.Order.OrderByDescending(x => x.GMT).Select(x => x).Take(5).ToList();
                st.OrderCount = model.Order.Count();

                DateTime asd = DateTime.Now.Date;
                List<Orders> order = model.Order.ToList();
                st.NewOrderNumber = order.Count(x => x.GMT.Date == asd);
                return View(st);
            }
        }
    }
}