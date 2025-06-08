using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using agent.Models;
using MySql.Data.MySqlClient;



namespace Agent.DB
    {
    public class MySqlData
        {
        static string connectionString = "Server=localhost;Port=3306;DataBase=classicmodels;User=root;Password='';";
        public MySqlConnection connection;

        public void Connect()
            {
            var conn = new MySqlConnection(connectionString);
            connection = conn;
            try
                {
                conn.Open();
                Console.WriteLine("Connected to MySQL DB");
                conn.Close();
                }
            catch (MySqlException ex)
                {
                Console.WriteLine($"Error connecting: {ex.Message}");
                }
            }
        }
    }
