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
                new Category {CategoryId=1, CategoryName="Food", CategoryDescription="A food group is a collection of foods that share similar nutritional properties or biological classifications.", CategoryImageUrl="FoodCate.jpg"},
                new Category {CategoryId=2, CategoryName="Sports", CategoryDescription="Sport is generally recognised as system of activities based in physical athleticism or physical dexterity.", CategoryImageUrl="SportsCate.jpg"},
                new Category {CategoryId=3, CategoryName="Home", CategoryDescription="Household goods are products that we buy and use within our homes.", CategoryImageUrl="HomeCate.jpg"},
                new Category {CategoryId=4, CategoryName="Kitchen", CategoryDescription="The kitchen is a core environment in a house and its essentially functional aim joins aesthetics.", CategoryImageUrl="KitchenCate.jpg"},
                new Category {CategoryId=5, CategoryName="Clothing", CategoryDescription="Clothing is any item worn on the body.", CategoryImageUrl="ClothingCate.jpg"}
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
    }
}
