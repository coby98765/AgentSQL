using Agent.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Agent.DB
    {
    public class MySqlData
        {
        static string connectionString = "Server=localhost;Port=3306;DataBase=eagleEyeDB;User=root;Password='';";
        private MySqlConnection _connection;

        public MySqlData()
            {
            var conn = new MySqlConnection(connectionString);
            _connection = conn;
            //testing connection
            try
                {
                conn.Open();
                Console.WriteLine("Connected to: 'eagleEyeDB'");
                conn.Close();
                }
            catch (MySqlException ex)
                {
                Console.WriteLine($"Error connecting: {ex.Message}");
                }
            }

        public MySqlConnection GetConnection()
            {
            _connection.Open();
            Console.WriteLine("Connection Opened.");
            return _connection;
            }

        public void closeConnection()
            {
            _connection.Close();
            Console.WriteLine("Connection Closed.");
            }
        }
    }
