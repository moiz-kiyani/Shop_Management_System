using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.GenericRepository
{
    public class Repository<T> : IRepository<T> where T : IEntity
    {
        public List<T> Items { get; set; }
        public List<T> categories { get; set; }

        public Repository()
        {
            Items = new List<T>();
            categories = new List<T>();
        }

        public T Get(int id)
        {
            return Items.FirstOrDefault(x => x.Id == id);
            return categories.FirstOrDefault(x => x.Id == id);  
        }

        public IEnumerable<T> GetAll()
        {
            return Items;
            return categories;
        }
    }
}
