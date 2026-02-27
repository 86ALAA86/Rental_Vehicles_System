using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_DataAccess_Layer
{
    public class clsEnginesData
    {
        public static DataTable GetAllEngines()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Engines order by EngineID";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static bool GetEngineInfoByID(int EngineID, ref string EngineName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            
            string query = "SELECT EngineName FROM Engines  WHERE EngineID=@EngineID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EngineID", EngineID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    EngineName = reader["EngineName"].ToString();

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool GetEngineInfoByName(string EngineName, ref int EngineID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT EngineID FROM Engines WHERE EngineName=@EngineName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EngineName", EngineName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    EngineID = (int)reader["EngineID"];

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

    }
}
