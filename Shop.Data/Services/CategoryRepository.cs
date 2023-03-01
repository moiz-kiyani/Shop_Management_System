using Shop.Data.GenericRepository;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Services
{
    public class CategoryRepository :Repository<Category> ,ICategoryRepository
    {
        public CategoryRepository()
        {
            categories = new List<Category>()
            {
                new Category {CategoryId=1, CategoryName="Food", CategoryDescription="urger is used to describe a.", CategoryImageUrl="c1.jpg"},
                new Category {CategoryId=2, CategoryName="Sports", CategoryDescription="bicycle, also called bike, ", CategoryImageUrl="c2.jpg"},
                new Category {CategoryId=3, CategoryName="Home", CategoryDescription="a large, rectangular piece of furniture, ", CategoryImageUrl="c3.jpg"},
                new Category {CategoryId=4, CategoryName="Kitchen", CategoryDescription="a glass or plastic container with a narrow neck, ", CategoryImageUrl="c4.jpg"},
                new Category {CategoryId=5, CategoryName="Clothing", CategoryDescription="CLOTH is a pliable material made usually by weaving, ", CategoryImageUrl="c5.jpg"}
            };

        }

        public Category Get(int id)
        {
            return categories.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Category> GetAll()
        {
            return categories;
        }

        public IEnumerable<Category> GetForCategory(int categoryId)
        {
            return Items.Where(x => x.CategoryId == categoryId).ToList<Category>();
        }
    }
}
