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
                conn.Open(); // date reported moved to report table 
                string sql = "SELECT p.pothole_id, p.severity, p.latitude, p.longitude, p.address, p.city, r.report_date, r.is_Reviewed," +
                    " r.report_notes, i.inspection_date, i.is_Inspected, i.inspection_notes, re.repair_date, re.is_Repaired, re.repair_notes " +
                    "FROM potholes p LEFT OUTER JOIN reports r ON r.pothole_id = p.pothole_id LEFT OUTER JOIN inspections i ON i.pothole_id = p.pothole_id " +
                    "LEFT OUTER JOIN repairs re ON re.pothole_id = p.pothole_id"; 
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Pothole newPothole = new Pothole();
                    newPothole.Id = Convert.ToInt32(reader["pothole_id"]);
                    newPothole.Severity = Convert.ToInt32(reader["severity"]);
                    newPothole.Latitude = Convert.ToString(reader["latitude"]);
                    newPothole.Longitude = Convert.ToString(reader["longitude"]);
                    newPothole.Address = Convert.ToString(reader["address"]);
                    newPothole.City = Convert.ToString(reader["city"]);
                    newPothole.ReportDate = Convert.ToDateTime(reader["report_date"]);
                    newPothole.IsReviewed = Convert.ToBoolean(reader["is_Reviewed"]);
                    newPothole.ReportNotes = Convert.ToString(reader["report_notes"]);
                    newPothole.InspectionDate = GetNullableDate(reader, "inspection_date");
                    newPothole.IsInspected = GetNullableBool(reader, "is_Inspected");
                    newPothole.InspectionNotes = Convert.ToString(reader["inspection_notes"]);
                    newPothole.RepairDate = GetNullableDate(reader, "repair_date");
                    newPothole.IsRepaired = GetNullableBool(reader, "is_Repaired");
                    newPothole.RepairNotes = Convert.ToString(reader["repair_notes"]);

                    potholes.Add(newPothole);
                }

            }
            return potholes;
        }

        private static DateTime GetNullableDate(SqlDataReader reader, string column)
        {
            if (reader[column] != DBNull.Value)
            {
                return Convert.ToDateTime(reader[column]);
            }
            else
            {
                return default;
            }
        }

        private static bool GetNullableBool(SqlDataReader reader, string column)
        {
            if (reader[column] != DBNull.Value)
            {
                return Convert.ToBoolean(reader[column]);
            }
            else
            {
                return default;
            }
        }

        public bool DeletePothole(int potholeId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM potholes WHERE pothole_id = @potholeId";

                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@potholeId", potholeId);

                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected > 0;
            }
        }

        public Pothole GetPothole(int potholeId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT p.pothole_id, p.severity, p.latitude, p.longitude, p.address, p.city FROM potholes p WHERE pothole_id = @potholeId";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@potholeId", potholeId);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Pothole pothole = GetPotholeFromDataReader(reader);
                    return pothole;
                }
            }
            return null;
        }

        public Pothole GetPotholeFromDataReader(SqlDataReader reader)
        {
            return new Pothole()
            {
                Id = Convert.ToInt32(reader["pothole_id"]),
                Severity = Convert.ToInt32(reader["severity"]),
                Latitude = Convert.ToString(reader["latitude"]),
                Longitude = Convert.ToString(reader["longitude"]),
                Address = Convert.ToString(reader["address"]),
                City = Convert.ToString(reader["city"])
            };
        }

        public Pothole AddPothole(Pothole newPothole )
        {
           
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO potholes (severity, latitude,longitude,address,city)" +
                    " VALUES(@severity,@latitude, @longitude, @address, @city);" +
                    " SELECT @@IDENTITY";
                SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@severity", newPothole.Severity);
                command.Parameters.AddWithValue("@latitude", newPothole.Latitude);
                command.Parameters.AddWithValue("@longitude", newPothole.Longitude);
                command.Parameters.AddWithValue("@address", newPothole.Address);
                command.Parameters.AddWithValue("@city", newPothole.City);

                int id = Convert.ToInt32(command.ExecuteScalar());
                newPothole.Id = id;

            }
                return newPothole;
        }
    }   
}
