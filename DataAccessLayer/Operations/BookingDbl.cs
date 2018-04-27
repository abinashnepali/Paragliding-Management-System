using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Operations
{
    public class BookingDbl
    {
        public int AddUpdateBooking(Book book)
        {
            using (SqlConnection con = new SqlConnection(Connection.connectionString))
            {
                SqlCommand cmd = new SqlCommand("Booking_AddUpdate", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BookID", book.BookID);
                cmd.Parameters.AddWithValue("@BookedFor", book.BookedFor);
                cmd.Parameters.AddWithValue("@BookedBy", book.BookedBy);
                cmd.Parameters.AddWithValue("@StaffID", book.StaffID);
                cmd.Parameters["@status"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return int.Parse(cmd.Parameters["@status"].Value.ToString());
            }
        }

        public int BookingCancel(int? bookID)
        {
            using (SqlConnection con = new SqlConnection(Connection.connectionString))
            {

                SqlCommand cmd = new SqlCommand("Booking_Cancel", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookID", bookID);
                con.Open();
                int affactedRow = cmd.ExecuteNonQuery();
                con.Close();
                return affactedRow;
            }
        }

        public IEnumerable<Book> GetAllBooking()
        {
            List<Book> lstBook = new List<Book>();
            using (SqlConnection con = new SqlConnection(Connection.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Booking;", con);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Book book = new Book();

                    book.BookID = Convert.ToInt32(rdr["BookID"]);
                    book.BookedBy = rdr["FirstName"].ToString();
                    book.BookedFor = rdr["LastName"].ToString();
                    book.BookedOn = rdr["Address"].ToString();
                    book.CanceledOn = rdr["Phone"].ToString();
                    book.StaffID = rdr["Email"].ToString();
                    book.Designation = rdr["Designation"].ToString();
                    book.HireDate = Convert.ToDateTime(rdr["HireDate"]);
                    lstStaff.Add(book);
                }
                con.Close();
            }
            return lstBook;
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
