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

                    SqlCommand cmd = new SqlCommand(@"INSERT into survey_result (surveyId, parkCode, parkName, emailAddress, state, activityLevel) VALUES (@surveyId, @parkCode, @parkName, @emailAddress, @state, @activityLevel)", conn);
                    cmd.Parameters.AddWithValue("@surveyId", survey.SurveyID);
                    cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                    cmd.Parameters.AddWithValue("@parkName", survey.ParkName);
                    cmd.Parameters.AddWithValue("@emailAddress", survey.Email);
                    cmd.Parameters.AddWithValue("@state", survey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);

                    cmd.ExecuteNonQuery();

                    SurveyCount(survey);
                    return true;
                }
            }
            catch (SqlException)
            {

            }
            return false;
        }

        public Dictionary<string, int> SurveyCount(SurveyModel survey)
        {
            Dictionary<string, int> output = new Dictionary<string, int>();

            foreach (var kvp in output)
            {
                if (output.ContainsKey(survey.ParkCode))
                {
                    output[survey.ParkCode] = TotalSurveys(survey.ParkCode);
                }
                else
                {
                    output.Add(survey.ParkCode, 1);
                }
            }

            return output;
        }

        public int TotalSurveys(string parkCode)
        {
            int voteCount = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(@"SELECT COUNT(parkCode) AS @voteCount FROM survey_result WHERE @parkCode = parkCode", conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);
                    cmd.Parameters.AddWithValue("@voteCount", voteCount);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        voteCount = Convert.ToInt32(reader["@voteCount"]);
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