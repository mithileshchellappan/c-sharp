using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Text_Editor.Models;

namespace Text_Editor.Controllers
{
    public class TextEditorController : Controller
    {
        private readonly IConfiguration _configuration;

        public TextEditorController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(TextEditor obj)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("InsertData", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", obj.Name);
                    command.Parameters.AddWithValue("@content", obj.Content);
                    command.ExecuteNonQuery();
                }
            }

            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            List<TextEditor> list = new List<TextEditor>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Text_Editor", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TextEditor file = new TextEditor();
                            file.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            file.Name = reader.GetString(reader.GetOrdinal("Name"));
                            file.Content = reader.GetString(reader.GetOrdinal("Content"));
                            list.Add(file);
                        }
                    }
                }
            }

            return View(list);
        }

        public IActionResult Edit(int itemId)
        {
            TextEditor file = new TextEditor();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand($"SELECT * FROM Text_Editor WHERE Id={itemId}", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            file.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            file.Name = reader.GetString(reader.GetOrdinal("Name"));
                            file.Content = reader.GetString(reader.GetOrdinal("Content"));
                        }
                    }
                }
            }

            return View(file);
        }

        [HttpPost]
        public IActionResult Edit(TextEditor obj)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UpdateData", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", obj.Id);
                    command.Parameters.AddWithValue("@name", obj.Name);
                    command.Parameters.AddWithValue("@content", obj.Content);
                    command.ExecuteNonQuery();
                }
            }

            return RedirectToAction("List");
        }

        public IActionResult Delete(int itemId)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand($"DELETE FROM Text_Editor WHERE Id={itemId}", connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            return RedirectToAction("List");
        }
    }
}

