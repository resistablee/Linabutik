﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _201224_LinaButikPanel.Controllers
{
    public class PanelController : Controller
    {
        // GET: Panel
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult asd()
        {
            return HttpNotFound();
        }
    }
}