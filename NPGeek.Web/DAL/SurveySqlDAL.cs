using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using NPGeek.Web.Models;

namespace NPGeek.Web.DAL
{
    public class SurveySqlDAL : ISurveyDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public bool MakePost(SurveyModel survey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(@"INSERT into survey_result (parkCode, emailAddress, state, activityLevel) VALUES ( @parkCode, @emailAddress, @state, @activityLevel)", conn);
                    cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", survey.Email);
                    cmd.Parameters.AddWithValue("@state", survey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);

                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return false;
        }

        public List<SurveyResult> GetSurveyCount()
        {
            List<SurveyResult> results = new List<SurveyResult>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select parkName, survey_result.parkCode, count(*) as voteCount from survey_result JOIN park ON park.parkCode = survey_result.parkCode GROUP BY survey_result.parkCode, parkName ORDER BY voteCount DESC;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        SurveyResult contents = new SurveyResult();

                        contents.ParkName = Convert.ToString(reader["parkName"]);
                        contents.ParkCode = Convert.ToString(reader["parkCode"]);
                        contents.VoteCount = Convert.ToInt32(reader["voteCount"]);

                        results.Add(contents);
                    }

                }
            }
            catch (SqlException ex)
            {

            }
            return results;

            // Call the database and get the number of votes per park

            //List<SurveyModel> surveys = new List<SurveyModel>();

            //foreach (var park in survey.Parks)
            //{
            //    SurveyModel temp = new SurveyModel();
            //    temp.VoteCount = TotalSurveys(park.ParkCode);
            //    temp.ParkCode = park.ParkCode;
            //    temp.ParkName = park.ParkName;
            //    surveys.Add(temp);
            //}

            //return surveys;
        }

        public int TotalSurveys(string parkCode)
        {
            int voteCount = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(@"SELECT COUNT(parkCode) AS Count FROM survey_result WHERE @parkCode = parkCode GROUP BY parkCode", conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);


                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        voteCount = Convert.ToInt32(reader["Count"]);
                    }
                }
            }
            catch (SqlException)
            {

            }
            return voteCount;
        }
    }
}