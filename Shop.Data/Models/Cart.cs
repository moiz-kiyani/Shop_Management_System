using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int ProCartId { get; set; }
        public string ProName { get; set; }
        public int ProQuantity { get; set; }
        public int ProPrice { get; set; }
        public int Bill { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
