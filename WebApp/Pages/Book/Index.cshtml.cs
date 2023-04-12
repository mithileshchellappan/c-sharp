using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace WebApplication1.Pages.Book
{
    public class IndexModel : PageModel
    {
        public List<Books> bookList = new();
        public void OnGet()
        {
            
                const string CONN_STRING = "Data Source=5CG6257NNF\\SQLEXPRESS;Initial Catalog=LMS_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                SqlConnection sqlConnection = new SqlConnection(CONN_STRING);
                sqlConnection.Open();

                string query = "select book_code, book_title, price from lms_book_details";
                SqlCommand cmd = new SqlCommand(query,sqlConnection);
                var reader = cmd.ExecuteReader();

                while (reader.Read()) { 
                    Books book = new Books();
                    book.Id = (string)reader["book_code"];
                    book.BookName = (string)reader["book_title"];
                    book.price = (int)reader["price"];

                    bookList.Add(book);
                }

            
        }
    }

    public class Books
    {
        public string Id { get; set; }

        public string BookName { get; set; }


        public string category { get; set; }


        public string author { get; set; }
        public string publication { get; set; }
        public string publish_date { get; set; }
        public int book_edition { get; set; }


        public decimal price { get; set; }

        public string rack_num { get; set; }

        public string date_arrival { get; set; }

        public string supplier_id { get; set; }



    }
}
