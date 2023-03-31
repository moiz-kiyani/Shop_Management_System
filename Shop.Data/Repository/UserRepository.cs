using NHibernate;
using NHibernate.Linq;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class UserRepository : IUserRepository 
    {
        private readonly ISession _session;

        public UserRepository(ISession session)
        {
            _session = session;
        }

        public bool Signin(string email, string password)
        {
            bool isAuthenticated = false;
            var user = _session.Query<User>().FirstOrDefault(x => x.Email == email && x.Password == password);
            if(user !=null)
            {
                isAuthenticated = true;
            }
            return isAuthenticated;
        }

        public void Signup(User user)
        {
            _session.Save(user);
        }
    }
}
