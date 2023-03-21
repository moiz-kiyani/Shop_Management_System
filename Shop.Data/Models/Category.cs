using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Shop.Data.Models
{
    public class Category : IEntity
    {
        //Product table ID
        public int Id { get; set; }
        public int CategoryId { get; set; }

        [Required(ErrorMessage ="Category Name Must be Spacified")]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string CategoryImageUrl { get; set; }

        public HttpPostedFileBase File { get; set; }

        //This will return the list of products
        //public virtual ICollection<Product> Products { get; set; }
    }
}
