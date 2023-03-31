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
        //public List<Category> categories;

        [Column("ID")]
        //IENTITY Id As Primary Key for All Models
        public virtual int Id { get; set; }

        [Column("Name")]
        [Required(ErrorMessage ="Name Must be Required ")]
        public virtual string Name { get; set; }

        [Column("Price")]
        [Required(ErrorMessage = "Price Must be Required ")]
        public virtual int Price { get; set; }

        [Column("Description")]
        public virtual string Description { get; set; }

        [Column("ImageUrl")]
        public virtual string ImageUrl { get; set; }

        [ForeignKey("Category")]
        [Column("CategoryID")]
        [Required(ErrorMessage = "Must Select the Category ")]
        public virtual int CategoryId { get; set; }
        //private IList<Category> _category = new List<Category>();

        //public virtual IList<Category> Category
        //{
        //    get { return _category; }
        //    set { _category = value; }
        //}

        [Column("Quantity")]
        public virtual int Quantity { get; set; }

        [NotMapped]
        public virtual HttpPostedFileBase File { get; set; }
        public virtual List<Category> categories { get; set; }
    }
}
