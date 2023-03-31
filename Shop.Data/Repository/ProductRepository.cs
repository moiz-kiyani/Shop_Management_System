using NHibernate;
using Shop.Data.GenericRepository;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace Shop.Data.Services
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ISession _session;

        public ProductRepository(ISession session)
        {
            _session = session;
        }


        public void Create(Product product)
        {
            _session.Save(product);
        }

        public void Delete(int id)
        {
            var product = _session.Get<Product>(id);
            _session.Delete(product);
        }

        public Product Get(int id)
        {
            return _session.Get<Product>(id);
        }

        public IEnumerable<Product> GetForProduct(int id)
        {
            return _session.Query<Product>().Where(x => x.CategoryId == id).ToList();
        }


        public List<Product> GetAll()
        
        {
            return _session.Query<Product>().ToList();
        }

        public List<Category> GetCategories()
        {

            return _session.Query<Category>().ToList();
        }

        public IEnumerable<Product> GetForCategory(int id)
        {
            return _session.Query<Product>().Where(x => x.CategoryId == id).ToList();
        }

        public IEnumerable<Product> Search(string search)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> SendToCart(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            _session.Update(product);
        }
    }
}
