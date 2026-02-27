using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_DataAccess_Layer
{
    public  class clsBodiesData
    {
        public static DataTable GetAllBodies()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Bodies order by BodyID";

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

        public static bool GetBodyInfoByID(int BodyID,ref string BodyName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT BodyName FROM Bodies WHERE BodyID=@BodyID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BodyID", BodyID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    BodyName = reader["BodyName"].ToString();

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

        public static bool GetBodyInfoByName(string BodyName,ref int BodyID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT BodyID FROM Bodies WHERE BodyName=@BodyName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BodyName", BodyName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    BodyID = (int)reader["BodyID"];

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
