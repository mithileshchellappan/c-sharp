using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace _24_3_Proj
{
    internal class SportsManagementSystem
    {
        static string connString = "Data Source=5CG6257NNF\\SQLEXPRESS;Initial Catalog=Assessment;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public SqlConnection connection = new SqlConnection(connString);
        
        enum MenuOptions { ADD_SPORTS = 1, ADD_SCOREBOARD, ADD_TOURNAMENT, REMOVE_SPORTS, EDIT_SCOREBOARD, REMOVE_PLAYERS, REMOVE_TOURNAMENT, EXIT };

        static void Main(string[] args)
        {
            SportsManagementSystem st = new SportsManagementSystem();

           st.RemoveTournament();
        }

        void AddSports()
        {
            string sportName = Console.ReadLine();

            try
            {
                this.connection.Open();
                SqlCommand cmd = this.connection.CreateCommand();
                cmd.CommandText = $"INSERT INTO Sport (SportName) Values ('{sportName}')";
                cmd.ExecuteReader().Close();
                Console.WriteLine("Added sport");

            }catch (Exception e)
            {
                Console.WriteLine("Err" + e.Message);
            }
        }

        void RemoveScoreboard(int tournamentID = 0) 
        {
            if (tournamentID == 0)
            {
                Console.Write("Enter Scoreboard ID to remove:");
                int sbID = Convert.ToInt32(Console.ReadLine());
                runCommand($"DELETE FROM Scoreboard WHERE ScoreboardID = {sbID}");

                Console.WriteLine("Deleted Successfully");
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

        }

        void RemoveTournament()
        {
            try
            {
                Console.Write("Enter tournament ID (Make sure there are no ScoreBoard associated to it):");
                int tournamentId = Convert.ToInt32(Console.ReadLine());
                RemoveScoreboard(tournamentId);
                runCommand($"DELETE FROM Tournament WHERE TournamentID = {tournamentId}");
                Console.Write("Deleted Successfully");

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
            Console.Write("Updated Successfully");
        }
        void AddScoreboard()
        {
            Console.Write("Enter Tournament ID:");
            int tournamentId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Scoreboard Name:");
            string sbName = Console.ReadLine();
            Random random = new Random();
             runCommand($"INSERT INTO Scoreboard (TournamentID, ScoreboardName,Score) VALUES ({tournamentId},'{sbName}',0)");


        }
        private void runCommand(string command)
        {
            try
            {
                if (this.connection.State == ConnectionState.Closed)
                {

                this.connection.Open();
                }
                SqlCommand cmd = this.connection.CreateCommand();
                cmd.CommandText = command;
                cmd.ExecuteReader().Close();
                this.connection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Err" + e.Message);
            }

        }
        //private void ShowTable(string tableName)
        //{
        //    this.connection.Open();
        //    SqlCommand cmd = this.connection.CreateCommand();
        //    cmd.CommandText = $"SELECT * FROM {tableName}";



        //}
    }
}
