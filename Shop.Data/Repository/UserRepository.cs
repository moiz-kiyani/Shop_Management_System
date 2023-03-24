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
        private readonly string Connect = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        public bool Signin(string email, string password)
        {
            bool isAuthenticated = false;
            using (SqlConnection conn = new SqlConnection(Connect))
            {
                string SigninQurey = "select Email,Password from [User] where Email=@Email and Password=@Password";
                var cmd = new SqlCommand(SigninQurey, conn);
                cmd.Parameters.AddWithValue("@Email",email);
                cmd.Parameters.AddWithValue("@Password", password);
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if(sdr.HasRows)
                {
                    isAuthenticated = true;
                }
                sdr.Close();
            }
            return isAuthenticated;
        }

        public void Signup(User user)
        {
            using (SqlConnection con = new SqlConnection(Connect))
            {
                string SignUpQurey = "insert into [User] values('" + user.Name + "', '" + user.Email + "', '" + user.Password + "')";
                var cmd = new SqlCommand(SignUpQurey, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
