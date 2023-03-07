using Shop.Data.Models;
using Shop.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Category = Shop.Web.Areas.Admin.Models.Category;
using Product = Shop.Web.Areas.Admin.Models.Product;

namespace Shop.Web.Areas.Admin.Controllers
{
    public class ManageController : Controller
    {
        // GET: Admin/Manage
        public ActionResult Show()
        {
            return View(Category.products);
        }

        // GET: Admin/Manage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Manage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Manage/Create
        [HttpPost]
        public ActionResult Create(Product pro)
        {
            Category.products.Add(pro);
            return RedirectToAction("Show");
        }


        // GET: Admin/Manage/Edit/5
        public ActionResult Edit(int id)
        {
            foreach (var product in Category.products)
            {
                if (product.ProId == id)
                {
                    return View(product);
                }
            }
            return RedirectToAction(nameof(Show));
        }

        // POST: Admin/Manage/Edit/5
        [HttpPost]
        public ActionResult Edit(Product pro)
        {
            foreach (var product in Category.products)
            {
                if (product.ProId == pro.ProId)
                {
                    product.ProductName = pro.ProductName;
                    product.ProductPrice = pro.ProductPrice;
                    product.ProductCategory = pro.ProductCategory;
                }
            }
            return RedirectToAction(nameof(Show));
        }

            // GET: Admin/Manage/Delete/5
            public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Manage/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Show");
            }
            catch
            {
                return View();
            }
        }
    }
}
