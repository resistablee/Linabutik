using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _201224_LinaButikPanel.Models
{
    public class MM_OrderDetails:IDisposable
    {
        public Products product { get; set; }

        public ProductImages pImage { get; set; }
        public List<ProductImages> pImages { get; set; }
        public List<SelectListItem> colors { get; set; }
        public List<SelectListItem> sizes { get; set; }

        public void Dispose() { }
    }
}