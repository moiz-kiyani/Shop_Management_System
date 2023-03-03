using Shop.Data.GenericRepository;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Services
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> Search(string search);
        IEnumerable<Product> GetForCategory(int id);
        IEnumerable<Product> SendToCart(int id);
    }
}
