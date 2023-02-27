using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Services
{
    public interface IProductRepository
    {
        IEnumerable<Products> GetAll();

        Products Get(int id);

        IEnumerable<Products> Search(string search);
    }
}
