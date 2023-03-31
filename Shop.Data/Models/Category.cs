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
        public virtual int Id { get; set; }

        
        //public int CategoryId { get; set; }

        [Column("Name")]
        [Required(ErrorMessage ="Category Name Must be Spacified")]
        public virtual string Name { get; set; }

        [Column("Description")]
        public virtual string Description { get; set; }

        [Column("ImageUrl")]
        public virtual string ImageUrl { get; set; }

        [NotMapped]
        public virtual HttpPostedFileBase File { get; set; }

        //This will return the list of products
        public virtual ICollection<Product> Products { get; set; }
    }
}
