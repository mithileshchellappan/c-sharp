using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ConsoleTables;

namespace _24_3_Proj
{
    internal class SportsManagementSystem
    {
        static string connString = "Data Source=5CG6257NNF\\SQLEXPRESS;Initial Catalog=Assessment;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public SqlConnection connection = new SqlConnection(connString);
        //enum MenuOptions { ADD_SPORTS = 1, ADD_SCOREBOARD, ADD_TOURNAMENT, REMOVE_SPORTS, EDIT_SCOREBOARD, REMOVE_PLAYERS, REMOVE_TOURNAMENT, EXIT };

        static void Main(string[] args)
        {
            SportsManagementSystem st = new SportsManagementSystem();

            st.RemoveSports();
        }

        void AddSports()
        {
            Console.Write("Enter Sport Name:");
            string sportName = Console.ReadLine();

            try
            {
                runCommand($"INSERT INTO Sport (SportName) Values ('{sportName}')");
                Console.WriteLine("Added sport");
                showtable("Sport");


            }
            catch (Exception e)
            {
                Console.WriteLine("Err" + e.Message);
            }
        }
        void RemoveSports()
        {
            Console.Write("Enter Sport ID to remove:");
            string sportID = Console.ReadLine();

            try
            {
                string output = runCommand($"DELETE FROM Scoreboard WHERE TournamentID IN (SELECT TournamentID From Tournament WHERE SportID = {sportID})");
                Console.WriteLine("Done ScoreBoard");
                runCommand($"DELETE FROM Player WHERE TournamentID IN (SELECT TournamentID From Tournament WHERE SportID = {sportID})");
                Console.WriteLine("Done Player");

                runCommand($"DELETE FROM Tournament WHERE SportID = {sportID}");
                Console.WriteLine("Done Tournamnet");

                runCommand($"DELETE FROM Sport WHERE SportID = {sportID}");
                Console.WriteLine("Deleted Sport and all its related Tournaments, ScoreBoard, and Players");


                showtable("Sport");


            }
            catch (Exception e)
            {
                Console.WriteLine("Err" + e.Message);
            }
        }

        void AddPlayer()
        {
            Console.Write("Enter PlayerName:");
            string playerName = Console.ReadLine();
            Console.Write("Enter Tournament ID:");
            int tournamentId = Convert.ToInt32(Console.ReadLine());
            runCommand($"INSERT INTO Player (PlayerName, TournamentID) VALUES ('{playerName}',{tournamentId})");
            Console.WriteLine("Inserted Player Successfully");

            showtable("Player");
        }
        void RemovePlayer()
        {
            Console.Write("Enter Player ID:");
            int playerId = Convert.ToInt32(Console.ReadLine());
            runCommand($"DELETE FROM Player WHERE PlayerID = {playerId}");
            Console.WriteLine("Deleted Player Successfully");

            showtable("Player");

        }

        void RemoveScoreboard(int tournamentID = 0) 
        {
            if (tournamentID == 0)
            {
                Console.Write("Enter Scoreboard ID to remove:");
                int sbID = Convert.ToInt32(Console.ReadLine());
                runCommand($"DELETE FROM Scoreboard WHERE ScoreboardID = {sbID}");
                Console.WriteLine("Deleted Successfully");
                showtable("Scoreboard");

            }
            else
            {
                Console.WriteLine($"Deleting scoreboards associated to tournamentId {tournamentID}");
                runCommand($"DELETE FROM Scoreboard WHERE TournamentID = {tournamentID}");

            }

        }

        void AddTournament()
        {
            Console.Write("Enter Sport ID:");
            int sportId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Tournament Name:");
            string tName = Console.ReadLine();
            Random random = new Random();
            int tournamentId = random.Next(100000, 999999);
           runCommand($"INSERT INTO Tournament (TournamentName,SportID) VALUES ('{tName}',{sportId})");
             Console.WriteLine("Tournament Added Successfully");
            showtable("Tournament");


        }

        void RemoveTournament()
        {
            try
            {
                Console.Write("Enter tournament ID (Make sure there are no ScoreBoard associated to it):");
                int tournamentId = Convert.ToInt32(Console.ReadLine());
                RemoveScoreboard(tournamentId);
                runCommand($"DELETE FROM Tournament WHERE TournamentID = {tournamentId}");
                Console.WriteLine("Deleted Successfully");
                showtable("Tournament");

            }
            catch(Exception E)
            {
            }
        }

        void EditScoreboard()
        {
            Console.Write("Enter ScoreBoard ID to update score:");
            int sbId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter score:");
            int score = Convert.ToInt32(Console.ReadLine());

            runCommand($"UPDATE Scoreboard SET Score = {score} WHERE ScoreboardID = {sbId}");
            Console.WriteLine("Updated Successfully");
            showtable("Scoreboard");

        }
        void AddScoreboard()
        {
            Console.Write("Enter Tournament ID:");
            int tournamentId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Scoreboard Name:");
            string sbName = Console.ReadLine();
            Random random = new Random();
            runCommand($"INSERT INTO Scoreboard (TournamentID, ScoreboardName,Score) VALUES ({tournamentId},'{sbName}',0)");
            Console.WriteLine("Inserted Successfully");
            showtable("Scoreboard");


        }
        private string runCommand(string command)
        {
            string result = "";
            try
            {
                if (this.connection.State == ConnectionState.Closed)
                {
                    this.connection.Open();
                }
                SqlCommand cmd = this.connection.CreateCommand();
                cmd.CommandText = command;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        result += reader[i].ToString() + " ";
                    }
                    result += Environment.NewLine;
                }
                reader.Close();
                this.connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Err" + e.Message);
            }
            return result;
        }


        private void showtable(string tableName)
        {
            string query = $"SELECT * FROM {tableName}";
            SqlCommand command = new SqlCommand(query, this.connection);
            if (this.connection.State == ConnectionState.Closed)
            {
                this.connection.Open();
            }
            SqlDataReader rd = command.ExecuteReader();
            var table = new ConsoleTable();

            //Console.WriteLine(rd.FieldCount);
            //Console.Write("Index \t");
            List<string> columnNames = new List<String>();
            for (int i = 0; i <rd.FieldCount; i++)//columns
            {
                string columnName = Convert.ToString(rd.GetName(i));
                columnNames.Add(columnName);
            }
            table.AddColumn(columnNames);
            while (rd.Read())
            {
                object[] rowValues = new object[rd.FieldCount];
                rd.GetValues(rowValues);
                table.AddRow(rowValues);
            }
            Console.WriteLine(table.ToString());




        }
    }
}
