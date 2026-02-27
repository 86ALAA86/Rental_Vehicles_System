using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_DataAccess_Layer
{
    public class clsDriveTypeData
    {



        public static DataTable GetAllDriveTypes()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM DriveTypes order by DriveType_ID";

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

        public static bool GetDriveTypeInfoByID(int DriveType_ID, ref string DriveType_Name)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT DriveType_Name FROM DriveTypes WHERE DriveType_ID=@DriveType_ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriveType_ID", DriveType_ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    DriveType_Name = reader["DriveType_Name"].ToString();

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

        public static bool GetDriveTypeInfoByName(string DriveType_Name, ref int DriveType_ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT DriveType_ID FROM DriveTypes WHERE DriveType_Name=@DriveType_Name";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriveType_Name", DriveType_Name);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    DriveType_ID = (int)reader["DriveType_ID"];

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
