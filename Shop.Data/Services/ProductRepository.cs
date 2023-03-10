using Shop.Data.GenericRepository;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Services
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository()
        {
            Items = new List<Product>()
            { 
                new Product {Id=1,CategoryId=1, Name="Burger", Description="Burger is used to describe a popular sandwich made from ground meats that are formed into a patty, cooked, and placed between two halves of a bun. Although the most common Burger is made with meat, there are many alternatives that do not include meat, such as tofu or ground vegetables. When made with beef, the meat is ground and blended together to form the patty.", Price=200, ImageUrl="Burger.jpg"},
                 new Product {Id=2,CategoryId=1, Name="Pasta", Description="A dish originally from Italy consisting of dough made from durum wheat, extruded or stamped into various shapes and cooked in boiling water, and typically served with a sauce.", Price=450, ImageUrl="Pasta.jpg"},
                  new Product {Id=3,CategoryId=1, Name="Pizza", Description="A dish of Italian origin, consisting of a flat round base of dough baked with a topping of tomatoes and cheese, typically with added meat, fish, or vegetables.", Price=3250, ImageUrl="Pizza.jpg"},
                   new Product {Id=4,CategoryId=1, Name="Fries", Description="French fries, chips, finger chips, french-fried potatoes, or simply fries, are batonnet or allumette-cut deep-fried potatoes of disputed origin from Belgium or France. They are prepared by cutting potatoes into even strips, drying them, and frying them, usually in a deep fryer.", Price=950, ImageUrl="Fries.jpg"},
                new Product {Id=5,CategoryId=2, Name="Cycle", Description="Bicycle, also called bike, two-wheeled steerable machine that is pedaled by the rider’s feet. On a standard bicycle the wheels are mounted in-line in a metal frame, with the front wheel held in a rotatable fork.", Price=25000, ImageUrl="Cycle.jpg"},
                 new Product {Id=6,CategoryId=2, Name="Bat&Ball", Description="Bat-and-ball games are field games played by two opposing teams. Action starts when the defending team throws a ball at a dedicated player of the attacking team, who tries to hit it with a bat and run between various safe areas in the field to score runs.", Price=1800, ImageUrl="BatAndBall.jpg"},
                  new Product {Id=7,CategoryId=2, Name="FootBall", Description="Association football, more commonly known as football or soccer, is a team sport played between two teams of 11 players who primarily use their feet to propel a ball around a rectangular field called a pitch.", Price=7565, ImageUrl="FootBall.jpg"},
                new Product {Id=8,CategoryId=3, Name="Bed", Description="A large, rectangular piece of furniture, often with four legs, used for sleeping on: He lived in a room with only two chairs, a bed, and a table.", Price=10000, ImageUrl="Bed.jpg"},
                 new Product {Id=9,CategoryId=3, Name="Side Lamp", Description="A bedside lamp is a light that is placed next to a bed. It is usually small in size so it can fit on a nightstand or table,", Price=7450, ImageUrl="SideLamp.jpg"},
                new Product {Id=10,CategoryId=4, Name="Bottle", Description="a glass or plastic container with a narrow neck, used for storing drinks or other liquids.", Price=510, ImageUrl="Bottle.jpg"},
                 new Product {Id=11,CategoryId=4, Name="Coffee Beater", Description="Its simplistic design and simple operating system make it simple to produce cream-rich coffee quickly and easily.", Price=999, ImageUrl="CoffeeBeater.jpg"},
                new Product {Id=12,CategoryId=5, Name="Cloth", Description="CLOTH is a pliable material made usually by weaving, felting, or knitting natural or synthetic fibers and filaments.", Price=6420, ImageUrl="Cloth.jpg"},
                 new Product {Id=13,CategoryId=5, Name="Shoes", Description="A shoe is an item of footwear intended to protect and comfort the human foot. They are often worn with a sock. Shoes are also used as an item of decoration and fashion. The design of shoes has varied enormously through time and from culture to culture, with form originally being tied to function.", Price=425000, ImageUrl="Shoes.jpg"},
                  new Product {Id=14,CategoryId=5, Name="Belt", Description="A strip of leather or other material worn, typically round the waist, to support or hold in clothes or to carry weapons.", Price=1450, ImageUrl="Belt.jpg"}

            };
            
        }

        public IEnumerable<Product> GetForCategory(int categoryId)
        {
            return Items.Where(x => x.CategoryId == categoryId).ToList<Product>();
        }

        public IEnumerable<Product> Search(string search)
        {
            return Items.Where(x=>x.Name.ToLower().Contains(search.ToLower())).ToList();
            
        }
        public IEnumerable<Product> SendToCart(int id)
        {
            return Items.Where(x => x.Id == id).ToList<Product>();
        }
    }
}
