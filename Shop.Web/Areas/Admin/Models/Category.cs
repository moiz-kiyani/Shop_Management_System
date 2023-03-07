using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web.Areas.Admin.Models
{
    public class Category
    {
        public int CatId { get; set; }
        public string CategoryName { get; set; }
        static public List<Product> products { get; set; } = new List<Product>();
    }
}