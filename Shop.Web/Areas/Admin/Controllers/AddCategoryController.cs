using Shop.Data.Models;
using Shop.Data.Services;
using System;
using System.Collections.Generic;
using System.IO;
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
            return View(db.GetAll());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            string filename = Path.GetFileName(category.File.FileName);
            string Extension = Path.GetExtension(category.File.FileName);
            string path = Path.Combine(Server.MapPath("~/Images/"), filename);
            category.CategoryImageUrl = "~/Images/" + filename;
            db.Create(category);
            {
                if (category.File != null)
                {
                    category.File.SaveAs(path);
                }
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public ActionResult Edit(int id)
        {
            var cat = db.Get(id);
            Session["Image"] = cat.CategoryImageUrl;
            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var dbCategory = db.Get(category.Id);
                if (category.File != null)
                {
                    string filename = Path.GetFileName(category.File.FileName);
                    string Extension = Path.GetExtension(category.File.FileName);
                    string path = Path.Combine(Server.MapPath("~/Images/"), filename);
                    category.CategoryImageUrl = "~/Images/" + filename;
                    //db.Create(category);
                    //db.edit

                    category.File.SaveAs(path);
                    if (!string.IsNullOrEmpty(dbCategory.CategoryImageUrl))
                    {
                        string OldPath = Server.MapPath(dbCategory.CategoryImageUrl);
                        if (System.IO.File.Exists(OldPath))
                        {
                            System.IO.File.Delete(OldPath);
                        }
                    }

                    return RedirectToAction("Index");
                }
                else
                {
                    db.Update(category);
                    return RedirectToAction("Index");
                }
            }

            return View(category);
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var category = db.Get(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.Delete(id);
                }
            return RedirectToAction("Index");
        }
    }


}
