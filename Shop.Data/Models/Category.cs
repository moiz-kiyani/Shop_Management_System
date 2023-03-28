using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Shop.Data.Models
{
    public class Category : IEntity
    {
        [Column("ID")]
        //Product table ID
        public int Id { get; set; }

        
        //public int CategoryId { get; set; }

        [Column("Name")]
        [Required(ErrorMessage ="Category Name Must be Spacified")]
        public string CategoryName { get; set; }

        [Column("Description")]
        public string CategoryDescription { get; set; }

        [Column("ImageUrl")]
        public string CategoryImageUrl { get; set; }

        [NotMapped]
        public HttpPostedFileBase File { get; set; }

        //This will return the list of products
        public virtual ICollection<Product> Products { get; set; }
    }
}
