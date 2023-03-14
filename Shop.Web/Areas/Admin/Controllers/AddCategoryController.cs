using Shop.Data.Models;
using Shop.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Areas.Admin.Controllers
{
    public class AddCategoryController : Controller
    {
        private readonly CategoryRepository db = new CategoryRepository();

        // GET: Admin/Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            db.Create(category);
            return View();
        }
    }
}