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
                    cmd.Parameters.AddWithValue("@surveyId", survey);
                    cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                    cmd.Parameters.AddWithValue("@parkName", survey);
                    cmd.Parameters.AddWithValue("@emailAddress", survey);
                    cmd.Parameters.AddWithValue("@state", survey);
                    cmd.Parameters.AddWithValue("@activityLevel", survey);

                    cmd.ExecuteNonQuery();

                    SurveyCount(survey.ParkCode);
                    return true;
                }
            }
            catch (SqlException)
            {

            }
            return false;
        }

        public Dictionary<string, int> SurveyCount(string parkCode)
        {
            Dictionary<string, int> output = new Dictionary<string, int>();

            output.Add("@parkCode", 1);
                return output;
        }
            
        

    }
}