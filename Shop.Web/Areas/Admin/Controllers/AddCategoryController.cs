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
        private readonly ApplicationDbContext _context;

        public AddCategoryController()
        {
            _context = new ApplicationDbContext();
        }

        /*This is a connection for Ado.Net*/
        //private readonly CategoryRepository db = new CategoryRepository();
        //private readonly ProductRepository pdb = new ProductRepository();

        // GET: Admin/Category
        public ActionResult Index()
        {
            CategoryRepository categoryRepository = new CategoryRepository(_context);
            return View(categoryRepository.GetAll());
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
            CategoryRepository categoryRepository = new CategoryRepository(_context);
            string filename = Path.GetFileName(category.File.FileName);
            string Extension = Path.GetExtension(category.File.FileName);
            string path = Path.Combine(Server.MapPath("~/Images/"), filename);
            category.CategoryImageUrl = "~/Images/" + filename;
            categoryRepository.Create(category);
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
            CategoryRepository categoryRepository = new CategoryRepository(_context);
            var cat = categoryRepository.Get(id);
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
            CategoryRepository categoryRepository = new CategoryRepository(_context);
            if (ModelState.IsValid)
            {
                var dbCategory = categoryRepository.Get(category.Id);
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
                    categoryRepository.Update(category);
                    return RedirectToAction("Index");
                }
            }

            return View(category);
        }

        public ActionResult Delete(int id)
        {
            CategoryRepository categoryRepository = new CategoryRepository(_context);
            var category = categoryRepository.Get(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            else
            {
                categoryRepository.Delete(id);
            }
            return RedirectToAction("Index");
        }

    }
}
