using Shop.Data.GenericRepository;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Services
{
    internal interface ICustomerRepository : IRepository<Product>
    {
        IEnumerable<Product> SendToCart(int id);
    }
}
