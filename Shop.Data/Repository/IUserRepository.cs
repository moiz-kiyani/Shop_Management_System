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
        User Signin(User user);
        void Signup(User user);
    }
}
