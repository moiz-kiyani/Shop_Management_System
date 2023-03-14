﻿using Shop.Data.GenericRepository;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Services
{
    public class CategoryRepository :Repository<Category> ,ICategoryRepository
    {
             private readonly string Connect = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        //public CategoryRepository()
        //{
        //    categories = new List<Category>()
        //    {
        //        new Category {CategoryId=1, CategoryName="Food", CategoryDescription="A food group is a collection of foods that share similar nutritional properties or biological classifications.", CategoryImageUrl="FoodCate.jpg"},
        //        new Category {CategoryId=2, CategoryName="Sports", CategoryDescription="Sport is generally recognised as system of activities based in physical athleticism or physical dexterity.", CategoryImageUrl="SportsCate.jpg"},
        //        new Category {CategoryId=3, CategoryName="Home", CategoryDescription="Household goods are products that we buy and use within our homes.", CategoryImageUrl="HomeCate.jpg"},
        //        new Category {CategoryId=4, CategoryName="Kitchen", CategoryDescription="The kitchen is a core environment in a house and its essentially functional aim joins aesthetics.", CategoryImageUrl="KitchenCate.jpg"},
        //        new Category {CategoryId=5, CategoryName="Clothing", CategoryDescription="Clothing is any item worn on the body.", CategoryImageUrl="ClothingCate.jpg"}
        //    };

        //}

        public void Create(Category category)
        {
            using (SqlConnection con = new SqlConnection(Connect))
            {
                string InsertQurey = "Insert into Category values('" + category.CategoryName + "','" + category.CategoryDescription + "','" + category.CategoryImageUrl + "')";
                var cmd = new SqlCommand(InsertQurey, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Category Get(Category category, int id)
        {
            List<Category> categories = new List<Category>();

            using (SqlConnection con = new SqlConnection(Connect))
            {
                string ShowDetailsQuery = "selct * from products where ID =" + id + "";
                SqlCommand cmd = new SqlCommand(ShowDetailsQuery, con);
                // cmd.ExecuteNonQuery();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sda.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    categories.Add(new Category
                    {
                        CategoryId = Convert.ToInt32(row[0]),
                        CategoryName = row[1].ToString(),
                        CategoryDescription = row[2].ToString(),
                        CategoryImageUrl = row[3].ToString(),
                    });
                }
                return category;
            }
        }

        public IEnumerable<Category> GetAll()
        {
            List<Category> categories = new List<Category>();

            using (SqlConnection con = new SqlConnection(Connect))
            {
                string ShowDetailsQuery = "select * from Products ";
                SqlCommand cmd = new SqlCommand(ShowDetailsQuery, con);
                // cmd.ExecuteNonQuery();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sda.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    categories.Add(new Category
                    {
                        CategoryId = Convert.ToInt32(row[0]),
                        CategoryName = row[1].ToString(),
                        CategoryDescription = row[2].ToString(),
                        CategoryImageUrl = row[3].ToString(),
                    });
                }
                return categories;
            }
        }

        public void Update(Category category)
        {
            using (SqlConnection con = new SqlConnection(Connect))
            {
                string UpdateQurey = "update Products set ProductName = '" + category.CategoryName + "','" + category.CategoryDescription + "','" + category.CategoryImageUrl + "',  where ID =" + category.Id + "";
                SqlCommand cmd = new SqlCommand(UpdateQurey, con);
                cmd.ExecuteNonQuery();
            }
        }
    }
}