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
        private readonly ApplicationDbContext _context;

        public AddProductController()
        {
            _context = new ApplicationDbContext();
        }

        /*This is a connection for Ado.Net*/
        //private readonly ProductRepository db = new ProductRepository();

        // GET: Admin/AddProduct
        public ActionResult Index()
        {
            ProductRepository productRepository = new ProductRepository(_context);
            return View(productRepository.GetAll());
        }

        public ActionResult ShowProduct(int id)
        {
            ProductRepository productRepository = new ProductRepository(_context);
            return View(productRepository.GetForProduct(id));
        }

        public ActionResult Create()
        {
            ProductRepository productRepository = new ProductRepository(_context);
            Product product = new Product();
            product.categories = productRepository.GetCategories();
            return View(product);
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            ProductRepository productRepository = new ProductRepository(_context);
            //List<Category> categories = categoryRepository.GetAll();
            //DropDownList dropDownList = new DropDownList();
            //dropDownList.DataSource = categories;
            // dropDownList.DataTextField = categories.
            //dropDownList.DataValueField = 

            string filename = Path.GetFileName(product.File.FileName);
            string Extension = Path.GetExtension(product.File.FileName);
            string path = Path.Combine(Server.MapPath("~/Images/"), filename);
            product.ImageUrl = "~/Images/" + filename;
            productRepository.Create(product);
                if (product.File != null)
                {
                    product.File.SaveAs(path);
                }
                return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ProductRepository productRepository = new ProductRepository(_context);
            var cat = productRepository.Get(id);
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
            ProductRepository productRepository = new ProductRepository(_context);
            if (ModelState.IsValid)
            {
                var dbCategory = productRepository.Get(product.Id);
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
                    productRepository.Update(product);
                    return RedirectToAction("Index");
                }
            }

            return View(product);
        }
    }
}