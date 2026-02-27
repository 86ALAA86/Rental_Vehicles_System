using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_DataAccess_Layer
{
    public class clsEngineCheckData
    {
        public static bool GetEngineInfoByID(int EngineCheckID, ref bool EngineStartsOk, ref bool EngineNoiseOk, ref bool OilLevelOk,
            ref bool WariningLightsOk, ref string EngineNotes)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM EngineChecks WHERE EngineCheckID=@EngineCheckID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EngineCheckID", EngineCheckID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                   EngineStartsOk=(bool)reader["EngineStartsOk"];
                    EngineNoiseOk = (bool)reader["EngineNoiseOk"];
                    OilLevelOk = (bool)reader["OilLevelOk"];
                    WariningLightsOk = (bool)reader["WarningLightsOk"];

                    if (reader["EngineNotes"] != DBNull.Value)
                        EngineNotes = (string)reader["EngineNotes"];
                    else
                        EngineNotes = string.Empty;


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

        public static int AddNewEngineCheck(bool EngineStartsOk, bool EngineNoiseOk, bool OilLevelOk,
             bool WarningLightsOk,  string EngineNotes)
        {
            int VehicleCheckID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Insert Into EngineChecks
           (EngineStartsOk,EngineNoiseOk,OilLevelOk,
             WarningLightsOk,EngineNotes)

            Values
           (@EngineStartsOk,@EngineNoiseOk,@OilLevelOk,
             @WarningLightsOk,@EngineNotes);
                           
                            SELECT SCOPE_IDENTITY();";



            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EngineStartsOk", EngineStartsOk);
            command.Parameters.AddWithValue("@EngineNoiseOk", EngineNoiseOk);
            command.Parameters.AddWithValue("@OilLevelOk", OilLevelOk);
            command.Parameters.AddWithValue("@WarningLightsOk", WarningLightsOk);
            if (EngineNotes == "")
                command.Parameters.AddWithValue("@EngineNotes", DBNull.Value);
            else
                command.Parameters.AddWithValue("@EngineNotes", EngineNotes);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    VehicleCheckID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                VehicleCheckID = -1;
            }

            finally
            {
                connection.Close();
            }


            return VehicleCheckID;

        }

        public static bool UpdateEngineCheck(int EngineCheckID,bool EngineStartsOk, bool EngineNoiseOk, bool OilLevelOk,
             bool WarningLightsOk, string EngineNotes)
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            int AffectedRows = 0;

            string query = @"Update EngineChecks
                           set EngineStartsOk=@EngineStartsOk,
                            EngineNoiseOk=@EngineNoiseOk,
                            OilLevelOk=@OilLevelOk,
                            WarningLightsOk=@WarningLightsOk,
                            EngineNotes=@EngineNotes
                
                      where EngineCheckID=@EngineCheckID;";



            SqlCommand command = new SqlCommand(query, connection);

           command.Parameters.AddWithValue("@EngineStartsOk", EngineStartsOk);
            command.Parameters.AddWithValue("@EngineNoiseOk", EngineNoiseOk);
            command.Parameters.AddWithValue("@OilLevelOk", OilLevelOk);
            command.Parameters.AddWithValue("@WarningLightsOk", WarningLightsOk);
            if (EngineNotes == "")
                command.Parameters.AddWithValue("@EngineNotes", DBNull.Value);
            else
                command.Parameters.AddWithValue("@EngineNotes", EngineNotes);

            try
            {
                connection.Open();

                AffectedRows = command.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                AffectedRows = 0;
            }

            finally
            {
                connection.Close();
            }


            return (AffectedRows > 0);

        }

        public static bool Delete(int EngineCheckID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete EngineChecks
                                where EngineCheckID = @EngineCheckID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EngineCheckID", EngineCheckID);

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
