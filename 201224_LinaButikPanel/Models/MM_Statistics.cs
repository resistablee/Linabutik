using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _201224_LinaButikPanel.Models
{
    public class MM_Statistics:IDisposable
    {
        public int CustomerCount { get; set; }
        public List<Orders> LastOrder { get; set; }
        public int NewOrderNumber { get; set; }
        public int OrderCount { get; set; }


        public void Dispose() { }
    }
}