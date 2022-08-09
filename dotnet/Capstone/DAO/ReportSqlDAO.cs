using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public class ReportSqlDAO
    {
        private string connectionString;

        public ReportSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Pothole> GetAllReviewedPotholes()
        {
            List<Pothole> reviewedPotholes = new List<Pothole>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT p.pothole_id, p.severity, p.latitude, p.longitude, p.address, p.city," +
                    " r.report_date, r.is_Reviewed, r.notes";
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Pothole pothole = new Pothole();
                    pothole.Id = Convert.ToInt32(reader["pothole_id"]);
                    pothole.Severity = Convert.ToInt32(reader["severity"]);
                    pothole.Latitude = Convert.ToString(reader["latitude"]);
                    pothole.Longitude = Convert.ToString(reader["longitude"]);
                    pothole.Address = Convert.ToString(reader["address"]);
                    pothole.City = Convert.ToString(reader["city"]);
                    pothole.ReportDate = Convert.ToDateTime(reader["report_date"]);
                    pothole.IsReviewed = Convert.ToBoolean(reader["is_Reviewed"]);
                    pothole.ReportNotes = Convert.ToString(reader["notes"]);
                    
                    

                    reviewedPotholes.Add(pothole);
                }
            }
            return reviewedPotholes;
        }   
    }
}
