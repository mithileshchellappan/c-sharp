using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace WebApplication1.Pages.Book
{
    public class DeleteBookModel : PageModel
    {
        public Books book = new Books();
        public string message = "";
        public string BookCode = "";
        public void OnGet()
        {
            try
            {
                BookCode = Request.Query["BookCode"];
                SqlConnection connection = new SqlConnection("Data Source=5CG6257NNF\\SQLEXPRESS;Initial Catalog=LMS_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = $"SELECT BOOK_CODE,BOOK_TITLE,author,CATEGORY,PUBLICATION,PUBLISH_DATE,BOOK_EDITION,PRICE FROM LMS_BOOK_DETAILS WHERE BOOK_CODE = '{BookCode}';";

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine((string)reader["BOOK_TITLE"]);
                    book.Id = (string)reader["BOOK_CODE"];
                    book.BookName = (string)reader["BOOK_TITLE"];
                    book.author = (string)reader["author"];
                    book.category = (string)reader["CATEGORY"];
                    book.publication = (string)reader["PUBLICATION"];
                    book.publish_date = Convert.ToString((DateTime)reader["PUBLISH_DATE"]);
                    book.book_edition = (int)reader["BOOK_EDITION"];
                    book.price = (int)reader["PRICE"];
                }
                Console.WriteLine($"{book.price},{book.book_edition}");
            }catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
        public void OnPost()
        {
            message = "";
            BookCode = Request.Query["BookCode"];
            SqlConnection connection = new SqlConnection("Data Source=5CG6257NNF\\SQLEXPRESS;Initial Catalog=LMS_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            try
            {
                cmd.CommandText = $"DELETE FROM LMS_BOOK_DETAILS WHERE BOOK_CODE='{BookCode}'";
                int rows = cmd.ExecuteNonQuery();
                message = "Deleted successfully";
                if (rows > 0)
                {
                    Response.Redirect("/Book");
                }
            }catch(Exception ex)
            {
                message = ex.Message;
                Console.WriteLine(ex.Message);
            }
        }
    }
}
