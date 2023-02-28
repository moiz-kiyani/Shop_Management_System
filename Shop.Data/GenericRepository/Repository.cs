﻿using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.GenericRepository
{
    public class Repository<T> : IRepository<T> where T : IEntity
    {
        List<Product> products;

        public Repository()
        {
            products = new List<Product>()
            {
                new Product {Id=1, Name="Burger", Description="urger is used to describe a popular sandwich made from ground meats that are formed into a patty, cooked, and placed between two halves of a bun. Although the most common Burger is made with meat, there are many alternatives that do not include meat, such as tofu or ground vegetables. When made with beef, the meat is ground and blended together to form the patty.", Price=200, ImageUrl="1.jpg"},
                new Product {Id=2, Name="Cycle", Description="bicycle, also called bike, two-wheeled steerable machine that is pedaled by the rider’s feet. On a standard bicycle the wheels are mounted in-line in a metal frame, with the front wheel held in a rotatable fork.", Price=25000, ImageUrl="2.jpg"},
                new Product {Id=3, Name="Bed", Description="a large, rectangular piece of furniture, often with four legs, used for sleeping on: He lived in a room with only two chairs, a bed, and a table.", Price=10000, ImageUrl="3.jpg"},
                new Product {Id=4, Name="Bottle", Description="a glass or plastic container with a narrow neck, used for storing drinks or other liquids.", Price=510, ImageUrl="4.jpg"},
                new Product {Id=5, Name="Cloth", Description="CLOTH is a pliable material made usually by weaving, felting, or knitting natural or synthetic fibers and filaments.", Price=6420, ImageUrl="5.jpg"}

            };

        }
        public T Get(int id)
        {
            return (T)products.AsEnumerable();
        }

        public IEnumerable<T> GetAll()
        {
            return (IEnumerable<T>)products;
        }

        public IEnumerable<T> Search(string Search)
        {
            return (IEnumerable<T>)products.Where(x => x.Name.ToLower().Contains(Search.ToLower())).ToList();
        }
    }
}