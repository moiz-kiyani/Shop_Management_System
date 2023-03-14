using Shop.Data.GenericRepository;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Services
{
    public class CustomerRepository : Repository<Product>, ICustomerRepository
    {
        public CustomerRepository()
        {
            //customer = new List<Customer>()
            //{
            //    new Customer { CustomerId = 1, CustomerName = "Moiz", MobileNo = "0333-5173589", Address = "123/abc Rawalpindi", City = "Rawalpindi", BankDetails = "1111-2222-3333-4444" }
            //};

        }
       
        public IEnumerable<Product> SendToCart(int id)
            {
                return Items.Where(x => x.Id == id).ToList<Product>();
            }

    }
}
