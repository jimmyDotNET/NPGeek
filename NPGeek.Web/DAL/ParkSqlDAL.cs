using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using NPGeek.Web.Models;

namespace NPGeek.Web.DAL
{
    public class ParkSqlDAL : IParkDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public List<ParkModel> GetAllParks()
        {
            List<ParkModel> parks = new List<ParkModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(@"SELECT parkCode, parkName, parkDescription FROM park", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ParkModel park = ParkReader(reader);
                        parks.Add(park);
                    }
                }
            }
            catch (SqlException)
            {

            }
            return parks;
        }

        private ParkModel ParkReader(SqlDataReader reader)
        {
            return new ParkModel()
            {
                ParkCode = Convert.ToString(reader["parkCode"]),
                ParkName = Convert.ToString(reader["parkName"]),
                ParkDescription = Convert.ToString(reader["parkDescription"])
            };
        }
    }
}