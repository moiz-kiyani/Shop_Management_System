using Shop.Data.Models;
using Shop.Data.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Shop.Web.Areas.Admin.Controllers
{
    public class AddProductController : Controller
    {
        private readonly ProductRepository db = new ProductRepository();
        private readonly CategoryRepository categoryRepository = new CategoryRepository();

        // GET: Admin/AddProduct
        public ActionResult Index()
        {
            return View(db.GetAll());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            //List<Category> categories = categoryRepository.GetAll();
            //DropDownList dropDownList = new DropDownList();
            //dropDownList.DataSource = categories;
           // dropDownList.DataTextField = categories.
            //dropDownList.DataValueField = 
            string filename = Path.GetFileName(product.File.FileName);
            string Extension = Path.GetExtension(product.File.FileName);
            string path = Path.Combine(Server.MapPath("~/Images/"), filename);
            product.ImageUrl = "~/Images/" + filename;
            db.Create(product);
            {
                if (product.File != null)
                {
                    product.File.SaveAs(path);
                }
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult Edit(int id)
        {
            var cat = db.Get(id);
            Session["Image"] = cat.ImageUrl;
            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var dbCategory = db.Get(product.Id);
                if (product.File != null)
                {
                    string filename = Path.GetFileName(product.File.FileName);
                    string Extension = Path.GetExtension(product.File.FileName);
                    string path = Path.Combine(Server.MapPath("~/Images/"), filename);
                    product.ImageUrl = "~/Images/" + filename;
                    //db.Create(category);
                    //db.edit

                    product.File.SaveAs(path);
                    if (!string.IsNullOrEmpty(dbCategory.ImageUrl))
                    {
                        string OldPath = Server.MapPath(dbCategory.ImageUrl);
                        if (System.IO.File.Exists(OldPath))
                        {
                            System.IO.File.Delete(OldPath);
                        }
                    }

                    return RedirectToAction("Index");
                }
                else
                {
                    db.Update(product);
                    return RedirectToAction("Index");
                }
            }

            return View(product);
        }
    }
}