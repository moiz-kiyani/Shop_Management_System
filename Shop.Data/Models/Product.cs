using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.ModelBinding;

namespace Shop.Data.Models
{
    public class Product : IEntity
    {
        //IENTITY Id
        public int Id { get; set; }
        //PRODUCT ID
        public int ProductId { get; set; }

        [Required(ErrorMessage ="Name Must be Required ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price Must be Required ")]
        public int Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        //public string CategoryType { get; set; }

        [Required(ErrorMessage = "Must Select the Category ")]
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        //public int TotalBill { get; set; }
        //This will return the instance of the category
       // public virtual Category Category { get; set; }
        public HttpPostedFileBase File { get; set; }

        public List<Category> categories { get; set; } 
    }
}
