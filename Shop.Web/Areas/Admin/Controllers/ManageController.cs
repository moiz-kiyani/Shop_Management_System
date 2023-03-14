using Shop.Data.Models;
using Shop.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
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


        // GET: Admin/Manage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Manage/Create
        [HttpPost]
        public ActionResult Create(Product pro)
        {
            string filename = Path.GetFileName(pro.File.FileName);
            string path = Path.Combine(Server.MapPath("/Images/"), filename);
            pro.Image = "~/Images/" + filename;
            Category.products.Add(pro);
             
            if(pro.File != null)
            { 
                pro.File.SaveAs(path);
            }
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
                if(pro.File!=null)
                {
                    string filename = Path.GetFileName(pro.File.FileName);
                    string path = Path.Combine(Server.MapPath("/Images/"), filename);
                    pro.Image = "~/Images/" + filename;

                    string OldPath = Request.MapPath(Session["Image"].ToString());

                    if (pro.File != null)
                    {
                        pro.File.SaveAs(path);
                        if(System.IO.File.Exists(OldPath))
                        {
                            System.IO.File.Delete(OldPath);
                        }
                    }
                    return RedirectToAction("Show");
                }

                else if (product.ProId == pro.ProId)
                {
                    product.ProductName = pro.ProductName;
                    product.ProductPrice = pro.ProductPrice;
                    product.ProductCategory = pro.ProductCategory;
                    product.Description = pro.Description;
                }
            }
            return RedirectToAction(nameof(Show));
        }

            // GET: Admin/Manage/Delete/5
            public ActionResult Delete(int id)
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

        // POST: Admin/Manage/Delete/5
        [HttpPost]
        public ActionResult Delete(Product pro)
        {
            foreach (var product in Category.products)
            {
                if (product.ProId == product.ProId)
                {
                    Category.products.Remove(product);
                    return RedirectToAction(nameof(Show));
                }
            }
            return RedirectToAction(nameof(Show));
        }
    }
}
