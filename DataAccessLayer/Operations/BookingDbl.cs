using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Operations
{
    public class BookingDbl
    {
        public IEnumerable<Book> GetAllBooking()
        {
            List<Book> lstBook = new List<Book>();
            using (SqlConnection con = new SqlConnection(Connection.connectionString))
            {
                SqlCommand cmd = new SqlCommand("Booking_GetAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Book book = new Book();
                    Users user = new Users();
                    user.Id = rdr["UserId"].ToString();
                    user.UserName = rdr["UserName"].ToString();
                    book.BookID = Convert.ToInt32(rdr["BookID"]);
                    book.BookedFors = Convert.ToDateTime(rdr["BookedFor"]);
                    book.BookedOn = Convert.ToDateTime(rdr["BookedOn"]);
                    book.StaffIDs = rdr["StaffID"].ToString();
                    book.FirstName = rdr["FirstName"].ToString();
                    book.Users = user;
                    lstBook.Add(book);
                }
                con.Close();
            }
            return lstBook;
        }
        public Book GetBookingByID(int? id)
        {
            Book book = new Book();
            Users user = new Users();
            using (SqlConnection con = new SqlConnection(Connection.connectionString))
            {
                SqlCommand cmd = new SqlCommand("Booking_GetAllByStaffID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaffID", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    user.Id = rdr["UserId"].ToString();
                    user.UserName = rdr["UserName"].ToString();
                    book.BookID = Convert.ToInt32(rdr["BookID"]);
                    book.BookedFors = Convert.ToDateTime(rdr["BookedFor"]);
                    book.BookedOn = Convert.ToDateTime(rdr["BookedOn"]);
                    book.StaffIDs = rdr["StaffID"].ToString();
                    book.Users = user;
                }
                con.Close();
                return book;
            }
        }
        public int AddUpdateBooking(Book book)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Connection.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("Booking_AddUpdate", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookID", book.BookID);
                    cmd.Parameters.AddWithValue("@BookedFors", book.BookedFors);
                    cmd.Parameters.AddWithValue("@BookedBy", book.BookedBy);
                    cmd.Parameters.AddWithValue("@StaffIDs", book.StaffIDs);

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
       
    }
}
