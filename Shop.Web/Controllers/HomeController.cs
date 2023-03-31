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
    public class HomeController : Controller
    {
        private readonly ProductRepository _productRepository;

        public HomeController()
        {

            var sessionFactory = new Configuration().Configure().BuildSessionFactory();
            var session = sessionFactory.OpenSession();
            _productRepository = new ProductRepository(session);

        }
        // GET: Home
        public ActionResult Index()
        {
            var model = _productRepository.GetAll();
            return View(model);
        }

    }
}