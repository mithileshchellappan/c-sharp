using Microsoft.Data.SqlClient;

namespace sql
{
    public class Class1
    {
       static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection("Data Source=5CG6257NNF\\SQLEXPRESS;Initial Catalog=Practice Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            //cmd.CommandText = "SELECT * FROM EmployeeDetails";
            //SqlDataReader reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    Console.WriteLine(reader.GetInt32(0));
            //}
            try
            {
            string id = Console.ReadLine();
            cmd.CommandText = $"SELECT COUNT(*) FROM EmployeeDetails WHERE Location='{id}'";
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    cmd.CommandText = $"UPDATE EmployeeDetails SET Salary= 100000 WHERE Location = '{id}'";

                    cmd.ExecuteReader().Close();
                    
                    cmd.CommandText = "SELECT * FROM EmployeeDetails";

                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        Console.WriteLine(rd.GetInt32(0));
                    }
                }
                else
                {
                    Console.WriteLine("The EmployeeId does not exist");
                }
           

            }catch(SqlException e)
            {
                Console.WriteLine($"Err: {e.Message}");
            }catch(FormatException e)
            {
                Console.WriteLine($"Format Err: {e.Message}");
            }catch(InvalidOperationException e)
            {
                Console.WriteLine($"Operation Err: {e.Message}");

            }

        }
    }
}