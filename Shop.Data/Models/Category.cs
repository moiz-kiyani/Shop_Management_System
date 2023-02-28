using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Category : IEntity
    {
        //Product table ID
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryType { get; set; } 

        //This will return the list of products
        public virtual ICollection<Product> Products { get; set; }
    }
}
