using Shop.Data.GenericRepository;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Services
{
    public class CartRepository : Repository<Product>, ICartRepository
    {
        public IEnumerable<Product> AddToCart(int id)
        {
            return Items.Where(x => x.Id == id).ToList<Product>();
        }
    }
}
