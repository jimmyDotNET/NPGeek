using NPGeek.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace NPGeek.Web.DAL
{
    public class WeatherSqlDAL : IWeatherDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public WeatherModel ParkWeather(string parkCode)
        {
            

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(@"SELECT * FROM weather 
                    JOIN park ON park.parkCode = weather.parkCode WHERE weather.parkCode = @parkCode", conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        WeatherModel w = new WeatherModel();

                        w.ParkCode = Convert.ToString(reader["parkCode"]);
                        w.FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]);
                        w.Low = Convert.ToInt32(reader["low"]);
                        w.High = Convert.ToInt32(reader["high"]);
                        w.Forecast = Convert.ToString(reader["forecast"]);

                        return w;
                    }
                }
            }
            catch (SqlException)
            {

            }
            return null;
        }
    }
}