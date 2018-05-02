using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Operations
{
    public class SearchPilot
    {
        public IEnumerable<Staff> Index(int? offSet, DateTime date)
        {
            List<Staff> lstPilot = new List<Staff>();

            using (SqlConnection con = new SqlConnection(Connection.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SearchPilot", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dateTime", date);
                cmd.Parameters.AddWithValue("@offSet", offSet);

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

                    lstPilot.Add(staff);
                }
                con.Close();
            }
            return lstPilot;
        }
        public int ChkBookingStat(Book book)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Connection.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("Booking_CheckAvailability", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@BookedFor", book.BookedFor);
                    cmd.Parameters.AddWithValue("@StaffID", book.StaffID);

                    SqlParameter outPutParameter = new SqlParameter();
                    outPutParameter.ParameterName = "@status";
                    outPutParameter.SqlDbType = SqlDbType.Int;
                    outPutParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outPutParameter);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return int.Parse(outPutParameter.Value.ToString());
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
