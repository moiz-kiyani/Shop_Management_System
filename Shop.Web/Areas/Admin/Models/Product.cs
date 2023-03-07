using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web.Areas.Admin.Models
{
    public class Product
    {
        public int ProId { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string ProductCategory { get; set; }

    }
}