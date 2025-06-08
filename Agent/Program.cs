using Agent.Models;
using Agent.DB;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;

namespace Agent.Models
    {
    class Program
        {
        static void Main(string[] args)
            {
            AgentDAL agentDAL = new AgentDAL();

            //create and add new agent
            //Agent newAgent = new Agent(0, "agent z", "Yaakov","base","active",1);
            //agentDAL.AddAgent(newAgent);

            //get agents
            //agentDAL.GetAllAgents();
            //agentDAL.GetAgent(3);

            //Delete Agent
            //agentDAL.DeleteAgent(5);


            //Update agents location
            agentDAL.UpdateAgentLocation(9, "home");
            agentDAL.UpdateAgentStatus(7, "Missing");
            agentDAL.UpdateAgentMissions(1);
            }
        }
    }