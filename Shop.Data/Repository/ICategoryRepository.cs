using Shop.Data.GenericRepository;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Services
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Create(Category category); 
        void Update(Category category);
        void Delete(int id);
    }
}
