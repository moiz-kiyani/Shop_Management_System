using NHibernate;
using Shop.Data.GenericRepository;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Services
{
    public class CategoryRepository :Repository<Category> ,ICategoryRepository
    {
        private readonly ISession _session;

        public CategoryRepository(ISession session)
        {
            _session = session;
        }

        public void Create(Category category)
        {
            _session.Save(category);
        }


        public Category Get(int id)
        {
            return _session.Get<Category>(id);
        }


        public List<Category> GetAll()
        {
            return _session.Query<Category>().ToList();
        }

        public void Update(Category category)
        {
            _session.Update(category);
        }

        public void Delete(int id)
        {
            var category = _session.Get<Category>(id);
            _session.Delete(category);
        }
    }
}
