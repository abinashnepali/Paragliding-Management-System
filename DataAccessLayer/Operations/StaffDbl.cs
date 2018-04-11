using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer.Operations
{
    public class StaffDbl
    {
        public int AddUpdateStaff(Staff staff)
        {
            using (SqlConnection con = new SqlConnection(Connection.connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddUpdateStaff", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@staffID", staff.StaffID);
                cmd.Parameters.AddWithValue("@firstName", staff.FirstName);
                cmd.Parameters.AddWithValue("@lastName", staff.LastName);
                cmd.Parameters.AddWithValue("@address", staff.Address);
                cmd.Parameters.AddWithValue("@phone", staff.Phone);
                cmd.Parameters.AddWithValue("@email", staff.Email);
                cmd.Parameters.AddWithValue("@designation", staff.Designation);
                cmd.Parameters.Add("@status", SqlDbType.Int);
                cmd.Parameters["@status"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return int.Parse(cmd.Parameters["@status"].Value.ToString());
            }
        }

        public int DeleteStaff(int? userID)
        {
            using (SqlConnection con = new SqlConnection(Connection.connectionString))
            {

                SqlCommand cmd = new SqlCommand("DeleteStaff", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StaffID", userID);
                con.Open();
                int affactedRow = cmd.ExecuteNonQuery();
                con.Close();
                return affactedRow;
            }
        }

        public IEnumerable<Staff> GetAllStaff()
        {
            List<Staff> lstStaff = new List<Staff>();
            using (SqlConnection con = new SqlConnection(Connection.connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllStaffs", con);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Staff staff = new Staff();

                    staff.StaffID = Convert.ToInt32(rdr["StaffID"]);
                    staff.FirstName = rdr["FirstName"].ToString();
                    staff.LastName = rdr["LastName"].ToString();
                    staff.Address = rdr["Address"].ToString();
                    staff.Phone = rdr["Phone"].ToString();
                    staff.Email = rdr["Email"].ToString();
                    staff.Designation = rdr["Designation"].ToString();
                    staff.HireDate = Convert.ToDateTime(rdr["HireDate"]);

                    lstStaff.Add(staff);
                }
                con.Close();
            }
            return lstStaff;
        }

        public Staff GetStaffByID(int? id)
        {
            Staff staff = new Staff();
            using (SqlConnection con = new SqlConnection(Connection.connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetStaffById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@staffId", id);


                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    staff.StaffID = Convert.ToInt32(rdr["StaffID"]);
                    staff.FirstName = rdr["FirstName"].ToString();
                    staff.LastName = rdr["LastName"].ToString();
                    staff.Address = rdr["Address"].ToString();
                    staff.Phone = rdr["Phone"].ToString();
                    staff.Email = rdr["Email"].ToString();
                    staff.Designation = rdr["Designation"].ToString();
                    staff.HireDate = Convert.ToDateTime(rdr["HireDate"]);
                }
                con.Close();
                return staff;
            }
        }

    }
}
