using System;
using System.Configuration;
using System.Data.SqlClient;

public class BookStatusUpdater
{
    private string _connectionString;

    public BookStatusUpdater()
    {
        _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
    }

    public void UpdateBookStatus(string bookID)
    {
        string query = "UPDATE tbl_new_book SET status = 'sold' WHERE bookID = @bookID";

        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@bookID", bookID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error updating book status: " + ex.Message);
        }
    }
}
