using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_DataAccess_Layer
{
    public class clsMaintenanceData
    {

        public static DataTable GetAllMaintenances()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select * from Maintenance ;";

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


        public static bool GetMaintenanceInfoByMaintenanceID(int MaintenanceID,ref int VehicleID,ref string Description,ref DateTime MaintenanceDate,ref
            float Cost,ref int MaintenanceCheckID,ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Maintenance WHERE MaintenanceID = @MaintenanceID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@MaintenanceID", MaintenanceID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    VehicleID = (int)reader["VehicleID"];
                    Description = (string)reader["Description"];
                    MaintenanceDate = (DateTime)reader["MaintenanceDate"];
                    Cost = Convert.ToSingle(reader["Cost"].ToString());
                    MaintenanceCheckID = (int)reader["MaintenanceCheckID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];



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
        public static int AddNewMaintenance(int VehicleID,string Description,DateTime MaintenanceDate,
            float Cost,int MaintenanceCheckID,int CreatedByUserID)
        {
            //this function will return the new person id if succeeded and -1 if not.
            int UserID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Maintenance ( VehicleID, Description, MaintenanceDate,
             Cost, MaintenanceCheckID, CreatedByUserID)
                             VALUES (@VehicleID, @Description, @MaintenanceDate,
             @Cost, @MaintenanceCheckID, @CreatedByUserID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@VehicleID", VehicleID);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@MaintenanceDate", MaintenanceDate);
            command.Parameters.AddWithValue("@Cost", Cost);
            command.Parameters.AddWithValue("@MaintenanceCheckID", MaintenanceCheckID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    UserID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return UserID;
        }


        public static bool UpdateMaintenace(int MaintenanceID, int VehicleID, string Description, DateTime MaintenanceDate,
            float Cost, int MaintenanceCheckID, int CreatedByUserID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Maintenance  
                            set
                                VehicleID = @VehicleID,
                                Description = @Description,
                                MaintenanceDate = @MaintenanceDate,
                                Cost = @Cost,
                                MaintenanceCheckID = @MaintenanceCheckID,
                                CreatedByUserID = @CreatedByUserID

                                where  MaintenanceID = @MaintenanceID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@VehicleID", VehicleID);
            command.Parameters.AddWithValue("@MaintenanceID", MaintenanceID);

            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@MaintenanceDate", MaintenanceDate);
            command.Parameters.AddWithValue("@Cost", Cost);
            command.Parameters.AddWithValue("@MaintenanceCheckID", MaintenanceCheckID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);



            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool DeleteMaintenance(int MaintenanceID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Maintenance 
                                where MaintenanceID = @MaintenanceID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@MaintenanceID", MaintenanceID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }

    }
}
