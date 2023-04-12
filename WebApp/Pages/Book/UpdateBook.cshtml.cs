using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace WebApplication1.Pages.Book
{
    public class UpdateBookModel : PageModel
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
        public IActionResult OnPost()
        {
            message = "";
            BookCode = Request.Query["BookCode"];
            try
            {
                SqlConnection connection = new SqlConnection("Data Source=5CG6257NNF\\SQLEXPRESS;Initial Catalog=LMS_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
                connection.Open();

                book.BookName = Request.Form["BookTitle"];
                book.author = Request.Form["Author"];
                book.category = Request.Form["Category"];
                book.publication = Request.Form["Publication"];
                book.publish_date = Request.Form["PublishDate"];
                book.book_edition = Convert.ToInt32(Request.Form["BookEdition"]);
                book.price = Convert.ToInt32(Request.Form["Price"]);

                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = $"UPDATE LMS_BOOK_DETAILS SET BOOK_TITLE  = '{book.BookName}', AUTHOR='{book.author}',CATEGORY='{book.category}' ,PUBLICATION='{book.publication}',PUBLISH_DATE='{book.publish_date}',BOOK_EDITION={book.book_edition},PRICE = {book.price} WHERE BOOK_CODE = '{BookCode}'";
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine(rowsAffected);
                return Redirect("http://localhost:5212/Book");
                    
            }catch (Exception ex)
            {
                message = ex.Message;
                Console.WriteLine(ex.Message);
                return Redirect("http://localhost:5212/Book");

            }
        }
    }
   
}
