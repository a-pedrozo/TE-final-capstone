using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class PotholeSqlDAO : IPotholeDAO
    {
        private string connectionString;
        
        public PotholeSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Pothole> GetAllPotholes()
        {

            List<Pothole> potholes = new List<Pothole>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT p.pothole_id, p.date_reported, p.severity, p.latitude, p.longitude, p.address, p.city FROM potholes p";
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Pothole newPothole = new Pothole();
                    newPothole.Id = Convert.ToInt32(reader["pothole_id"]);
                    newPothole.DateReported = Convert.ToDateTime(reader["date_reported"]);
                    newPothole.Severity = Convert.ToInt32(reader["severity"]);
                    newPothole.Latitude = Convert.ToString(reader["latitude"]);
                    newPothole.Longitude = Convert.ToString(reader["longitude"]);
                    newPothole.Address = Convert.ToString(reader["address"]);
                    newPothole.City = Convert.ToString(reader["city"]);

                    potholes.Add(newPothole);
                }

            }

            
            return potholes;
                
        }
    }   
}
