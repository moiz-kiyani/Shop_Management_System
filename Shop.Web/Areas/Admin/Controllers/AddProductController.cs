using NHibernate.Cfg;
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
    [Authorize]
    public class AddProductController : Controller
    {
        private readonly ProductRepository _productRepository;

        public AddProductController()
        {

            var sessionFactory = new Configuration().Configure().BuildSessionFactory();
            var session = sessionFactory.OpenSession();
            _productRepository = new ProductRepository(session);

        }


        // GET: Admin/AddProduct
        public ActionResult Index()
        {
            var product = _productRepository.GetAll();
            return View(product);
        }

        public ActionResult ShowProduct(int id)
        {
            return View(_productRepository.GetForProduct(id));
        }

        public ActionResult Create()
        {
            Product product = new Product();
            product.categories = _productRepository.GetCategories();
            return View(product);
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {

            string filename = Path.GetFileName(product.File.FileName);
            string Extension = Path.GetExtension(product.File.FileName);
            string path = Path.Combine(Server.MapPath("~/Images/"), filename);
            product.ImageUrl = "~/Images/" + filename;
            _productRepository.Create(product);
                if (product.File != null)
                {
                    product.File.SaveAs(path);
                }
                return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var cat = _productRepository.Get(id);
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
                var dbCategory = _productRepository.Get(product.Id);
                if (product.File != null)
                {
                    string filename = Path.GetFileName(product.File.FileName);
                    string Extension = Path.GetExtension(product.File.FileName);
                    string path = Path.Combine(Server.MapPath("~/Images/"), filename);
                    product.ImageUrl = "~/Images/" + filename;

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
                    _productRepository.Update(product);
                    return RedirectToAction("Index");
                }
            }

            return View(product);
        }
    }
}