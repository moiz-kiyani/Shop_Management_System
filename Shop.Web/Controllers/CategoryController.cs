using NHibernate.Cfg;
using Shop.Data.Models;
using Shop.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly ProductRepository _productRepository;

        public CategoryController()
        {

            var sessionFactory = new Configuration().Configure().BuildSessionFactory();
            var session = sessionFactory.OpenSession();
            _categoryRepository = new CategoryRepository(session);
            _productRepository = new ProductRepository(session);

        }

        public ActionResult Categories()
        {
            var model = _categoryRepository.GetAll();
            return View(model);
        }

        public ActionResult CategoryProducts(int id)
        {
            var model = _productRepository.GetForCategory(id);
            return View(model);
        }
    }
}