using Agent.DB;
using Agent.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent.Models
    {
    internal class AgentDAL
        {
        private MySqlData _sqlData;
        // Constructor
        public AgentDAL()
            {
            _sqlData = new MySqlData();
            }

        // Methods

        //get a single agent
        public Agent GetAgent(int agentId)
            {
            Agent agent = null;
            MySqlDataReader reader = null;
            string query = $"SELECT * FROM agents WHERE agents.id = {agentId};";
            MySqlCommand cmd = null;
            try
                {
                MySqlConnection connection = _sqlData.GetConnection();
                cmd = new MySqlCommand(query, connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                    {
                    int id = reader.GetInt32("id");
                    string codeName = reader.GetString("codeName");
                    string realName = reader.GetString("realName");
                    string location = reader.GetString("location");
                    string status = reader.GetString("status");
                    int missionsCompleted = reader.GetInt32("missionsCompleted");

                    agent = new Agent(id, codeName, realName, location, status, missionsCompleted);
                    agent.printDetails();
                    }
                }
            catch (Exception ex)
                {
                Console.WriteLine($"Error while fetching agent: {ex.Message}");
                throw;
                }
            finally
                {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
                _sqlData.closeConnection();
                }
            return agent;
            }

        //add a single agent
        public void AddAgent(Agent agent)
            {
            
            string query = @"INSERT INTO agents
                           (codeName,realName,location,status,missionsCompleted)
                            VALUES(@codeName,@realName,@location,@status,@missionsCompleted)";
            MySqlCommand cmd = new MySqlCommand(query, _sqlData.GetConnection());
            try
                {
                cmd.Parameters.AddWithValue("@codeName", agent.CodeName);
                cmd.Parameters.AddWithValue("@realName", agent.RealName);
                cmd.Parameters.AddWithValue("@location", agent.Location);
                cmd.Parameters.AddWithValue("@status", agent.Status);
                cmd.Parameters.AddWithValue("@missionsCompleted", agent.MissionsCompleted);

                int rowsAfected = cmd.ExecuteNonQuery();
                Console.WriteLine(rowsAfected>0
                    ? "Agent Added."
                    : "No rows inserted.");
                agent.printDetails();
                }
            catch (Exception ex)
                {
                Console.WriteLine(ex.Message);
                }
            finally
                {
                _sqlData.closeConnection();
                }
            }
        
        //get all agents
        public List<Agent> GetAllAgents()
            {
            List<Agent> AgentList = new List<Agent>();
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            string query = "SELECT * FROM `agents`";
            try
                {
                MySqlConnection connection = _sqlData.GetConnection();
                cmd = new MySqlCommand(query, connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                    {
                    int id = reader.GetInt32("id");
                    string codeName = reader.GetString("codeName");
                    string realName = reader.GetString("realName");
                    string location = reader.GetString("location");
                    string status = reader.GetString("status");
                    int missionsCompleted = reader.GetInt32("missionsCompleted");

                    Agent agent = new Agent(id, codeName, realName, location, status, missionsCompleted);
                    agent.printDetails();
                    AgentList.Add(agent);
                    }
                }
            catch (Exception ex)
                {
                Console.WriteLine($"Error while fetching agent: {ex.Message}");
                }
            finally
                {
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                _sqlData.closeConnection();
                }

            return AgentList;
            }

        //Update location
        public void UpdateAgentLocation(int agentId, string newLocation)
            {
            string query = $"UPDATE agents SET location = '{newLocation}' WHERE id = {agentId};";
            MySqlCommand cmd = new MySqlCommand(query, _sqlData.GetConnection());
            try
                {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Location Updated.");
                }
            catch (Exception ex)
                {
                Console.WriteLine(ex.Message);
                }
            finally
                {
                _sqlData.closeConnection();
                }
            }

        //Update Status
        public void UpdateAgentStatus(int agentId, string newStatus)
            {
            string[] statusOptions = { "Active", "Injured", "Missing", "Retired" };
            if(statusOptions.Contains(newStatus)){

                
            string query = $"UPDATE agents SET STATUS = '{newStatus}' WHERE id = {agentId};";
            MySqlCommand cmd = new MySqlCommand(query, _sqlData.GetConnection());
            try
                {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Status Updated.");
                }
            catch (Exception ex)
                {
                Console.WriteLine(ex.Message);
                }
            finally
                {
                _sqlData.closeConnection();
                }
                }
            else
                {
                Console.WriteLine("Status not allowed");
                }
            }

        //Update location
        public void UpdateAgentMissions(int agentId, int newMissDone = 1)
            {
            Agent current = GetAgent(agentId);
            string query = $"UPDATE agents SET missionsCompleted = '{current.MissionsCompleted + newMissDone}' WHERE id = {agentId};";
            MySqlCommand cmd = new MySqlCommand(query, _sqlData.GetConnection());
            try
                {
                cmd.ExecuteNonQuery();
                Console.WriteLine($"MissionsCompleted added {newMissDone}.");
                }
            catch (Exception ex)
                {
                Console.WriteLine(ex.Message);
                }
            finally
                {
                _sqlData.closeConnection();
                }
            }

        //Delete
        public void DeleteAgent(int agentId)
            {
            string query = $"DELETE FROM agents WHERE agents.id = {agentId};";
            try
                {
                MySqlCommand cmd = new MySqlCommand(query, _sqlData.GetConnection());
                cmd.ExecuteNonQuery();
                Console.WriteLine("Deleted.");
                }
            catch(Exception ex)
                {
                Console.WriteLine(ex.Message);
                }
            finally
                {
                _sqlData.closeConnection();
                }

            }
        }
    }
