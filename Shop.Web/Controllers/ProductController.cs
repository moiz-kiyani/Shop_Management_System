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
    public class ProductController : Controller
    {
        private readonly ProductRepository _productRepository;

        public ProductController()
        {

            var sessionFactory = new Configuration().Configure().BuildSessionFactory();
            var session = sessionFactory.OpenSession();
            _productRepository = new ProductRepository(session);

        }

        // GET: Product
        public ActionResult Index()
        {
            var model = _productRepository.GetAll();
            
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = _productRepository.Get(id);

            return View(model);
        }
        public ActionResult Search(string search)
        {
            var model = _productRepository.Search(search);

            return View(model);
        }

    }
}