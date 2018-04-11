using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer.Operations
{
    public class Logindbl
    {
        public bool ValidateUser(string email, string password)
        {
            using (SqlConnection con = new SqlConnection(Connection.connectionString))
            {
                SqlCommand cmd = new SqlCommand("UserLogin", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);

                con.Open();
                int count = (int)cmd.ExecuteScalar();
                if (count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Users GetUserDetails(string email)
        {
            Users user = new Users();
            using (SqlConnection con = new SqlConnection(Connection.connectionString))
            {
                SqlCommand cmd = new SqlCommand("UserDetails", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@email", email);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    user.UserID = Convert.ToInt32(rdr["UserID"]);
                    user.FirstName = rdr["FirstName"].ToString();
                    user.LastName = rdr["LastName"].ToString();
                    user.Email = rdr["Email"].ToString();
                    user.Phone = rdr["Phone"].ToString();
                    user.RoleType = Convert.ToInt32(rdr["RoleType"]);
                }
                con.Close();
                return user;

            }
        }

        public int DeleteUser(int? userID)
        {
            using (SqlConnection con = new SqlConnection(Connection.connectionString))
            {

                SqlCommand cmd = new SqlCommand("DeleteUser", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserID", userID);
                con.Open();
                int affactedRow = cmd.ExecuteNonQuery();
                con.Close();
                return affactedRow;
            }
        }

        public IEnumerable<Users> GetAllUsers()
        {
            List<Users> lstUser = new List<Users>();
            using (SqlConnection con = new SqlConnection(Connection.connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllUsers", con);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Users user = new Users();

                    user.UserID = Convert.ToInt32(rdr["UserID"]);
                    user.FirstName = rdr["FirstName"].ToString();
                    user.LastName = rdr["LastName"].ToString();
                    user.Email = rdr["Email"].ToString();
                    user.RoleType = Convert.ToInt32(rdr["RoleType"]);

                    lstUser.Add(user);
                }
                con.Close();
            }
            return lstUser;
        }

        public Users GetUserByID(int? id)
        {
            Users user = new Users();
            using (SqlConnection con = new SqlConnection(Connection.connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetUserById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", id);


                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    user.UserID = Convert.ToInt32(rdr["UserID"]);
                    user.FirstName = rdr["FirstName"].ToString();
                    user.LastName = rdr["LastName"].ToString();
                    user.Email = rdr["Email"].ToString();
                    user.Phone = rdr["Phone"].ToString();
                    user.RoleType = Convert.ToInt32(rdr["RoleType"]);
                }
                con.Close();
                return user;
            }
        }
    }
}
