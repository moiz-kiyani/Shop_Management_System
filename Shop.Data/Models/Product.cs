using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.ModelBinding;

namespace Shop.Data.Models
{
    [Table("Products")]
    public class Product : IEntity
    {
        public List<Category> categories;

        [Column("ID")]
        //IENTITY Id As Primary Key for All Models
        public int Id { get; set; }

        
        //PRODUCT ID
        //public int ProductId { get; set; }

        [Column("Name")]
        [Required(ErrorMessage ="Name Must be Required ")]
        public string Name { get; set; }

        [Column("Price")]
        [Required(ErrorMessage = "Price Must be Required ")]
        public int Price { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("ImageUrl")]
        public string ImageUrl { get; set; }
        //public string CategoryType { get; set; }

        [ForeignKey("Category")]
        [Column("CategoryID")]
        [Required(ErrorMessage = "Must Select the Category ")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Column("Quantity")]
        public int Quantity { get; set; }
        //public int TotalBill { get; set; }
        //This will return the instance of the category
        // public virtual Category Category { get; set; }

        [NotMapped]
        public HttpPostedFileBase File { get; set; }

        //public List<Category> categories { get; set; } 
    }
}
