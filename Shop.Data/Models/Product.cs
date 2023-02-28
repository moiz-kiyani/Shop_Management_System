using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Product : IEntity
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Categories { get; set; }

        //This will return the instance of the category
        public virtual Category Category { get; set; }


    }
}
