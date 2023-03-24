using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    internal interface IUserRepository
    {
        bool Signin(string email, string password);
        void Signup(User user);
    }
}
