using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class DAL
    {
        string connectionString = "Data Source=.;Initial Catalog=ParaglidingMS;Integrated Security=True;Connect Timeout=120";

        public bool ValidateUser(string email, string password)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
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

        public int AddUpdateUser(Users user)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddUpdateUser", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@userID", user.UserID);
                cmd.Parameters.AddWithValue("@firstName", user.FirstName);
                cmd.Parameters.AddWithValue("@lastName", user.LastName);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@phone", user.Phone);
                cmd.Parameters.AddWithValue("@roleType", user.RoleType);
                cmd.Parameters.Add("@status", SqlDbType.Int);
                cmd.Parameters["@status"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return int.Parse(cmd.Parameters["@status"].Value.ToString());
            }
        }

        public int DeleteUser(int userID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
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
            using (SqlConnection con = new SqlConnection(connectionString))
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
            using (SqlConnection con = new SqlConnection(connectionString))
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