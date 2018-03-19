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
        private string connectionString;

        public ParkSqlDAL(IContext context)
        {
            connectionString = context.ConnectionString;
        }
        

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

        public ParkModel GetParkDetail(string parkCode)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(@"SELECT * FROM park WHERE parkCode = @parkCode;", conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ParkModel p = new ParkModel();

                        p.ParkCode = Convert.ToString(reader["parkCode"]);
                        p.ParkName = Convert.ToString(reader["parkName"]);
                        p.State = Convert.ToString(reader["state"]);
                        p.Acreage = Convert.ToInt32(reader["acreage"]);
                        p.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
                        p.MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]);
                        p.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
                        p.Climate = Convert.ToString(reader["climate"]);
                        p.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                        p.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
                        p.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
                        p.QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        p.ParkDescription = Convert.ToString(reader["parkDescription"]);
                        p.EntryFee = Convert.ToInt32(reader["entryFee"]);
                        p.NumberOfSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);

                        return p;
                    }
                }
            }
            catch (SqlException)
            {

            }
            return null;
        }

    private ParkModel ParkReader(SqlDataReader reader)
    {
        return new ParkModel()
        {
            ParkCode = Convert.ToString(reader["parkCode"]),
            ParkName = Convert.ToString(reader["parkName"]),
            ParkDescription = Convert.ToString(reader["parkDescription"]),
        };
    }
}
}