using agent.Models;
using Agent.DB;
using MySql.Data.MySqlClient;


namespace agent.Models
    {
    class Program
        {
        static void Main(string[] args)
            {
            MySqlData mySqlData = new MySqlData();
            mySqlData.Connect();
            }
        }
    }