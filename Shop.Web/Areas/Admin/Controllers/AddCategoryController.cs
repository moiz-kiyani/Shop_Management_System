using NHibernate.Cfg;
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
    [Authorize]
    public class AddCategoryController : Controller
    {
        private readonly CategoryRepository _categoryRepository;

        public AddCategoryController()
        {

            var sessionFactory = new Configuration().Configure().BuildSessionFactory();
            var session = sessionFactory.OpenSession();
            _categoryRepository = new CategoryRepository(session);

        }


        // GET: Admin/Category
        public ActionResult Index()
        {
            return View(_categoryRepository.GetAll());
        }

        public ActionResult GoToProducts(int id)
        {
            return RedirectToAction("ShowProduct","AddProduct", new { id = id });
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
            category.ImageUrl = "~/Images/" + filename;
            _categoryRepository.Create(category);
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
            var cat = _categoryRepository.Get(id);
            Session["Image"] = cat.ImageUrl;
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
                var dbCategory = _categoryRepository.Get(category.Id);
                if (category.File != null)
                {
                    string filename = Path.GetFileName(category.File.FileName);
                    string Extension = Path.GetExtension(category.File.FileName);
                    string path = Path.Combine(Server.MapPath("~/Images/"), filename);
                    category.ImageUrl = "~/Images/" + filename;

                    category.File.SaveAs(path);
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
                    _categoryRepository.Update(category);
                    return RedirectToAction("Index");
                }
            }

            return View(category);
        }

        public ActionResult Delete(int id)
        {
            var category = _categoryRepository.Get(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            else
            {
                _categoryRepository.Delete(id);
            }
            return RedirectToAction("Index");
        }

    }
}
