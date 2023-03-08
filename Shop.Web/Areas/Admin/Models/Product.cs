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
        public string Description { get; set; }
        public string Image { get; set; }
        public HttpPostedFileBase File { get; set; }

    }
}