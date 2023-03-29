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
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /*The below connection string is for ado.net*/
        //private readonly string Connect = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        public bool Signin(string email, string password)
        {
            bool isAuthenticated = false;

                        /*The below code is for ado.net*/
            //using (var db = new ApplicationDbContext())
            //{
            //    var user = db.users.FirstOrDefault(u => u.Email == email && u.Password == password);
            //    if (user != null)
            //    {
            //        isAuthenticated = true;
            //    }
            //      return isAuthenticated;}
            var user = _context.users.FirstOrDefault(x => x.Email == email && x.Password == password);
            if(user !=null)
            {
                isAuthenticated = true;
            }
            return isAuthenticated;
        }

        public void Signup(User user)
        {
            _context.users.Add(user);
            _context.SaveChanges();

            /*The below connection string is for ado.net*/
            //using (SqlConnection con = new SqlConnection(Connect))
            //{
            //    string SignUpQurey = "insert into [User] values('" + user.Name + "', '" + user.Email + "', '" + user.Password + "')";
            //    var cmd = new SqlCommand(SignUpQurey, con);
            //    con.Open();
            //    cmd.ExecuteNonQuery();
            //}
        }
    }
}
