using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _201224_LinaButikPanel.Controllers
{
    public class MapController : Controller
    {
        // GET: Map
        public ActionResult GoogleMapAPI()
        {
            string[,] coordinates = {
                  { "37.7406885", "29.1211469"} , //ev
                  { "37.7378182", "29.1072259"} , //paü
                  { "37.7531517", "29.0910879"}   //forum çamlık
                };
            return View(coordinates);
        }
    }
}