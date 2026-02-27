using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_DataAccess_Layer
{
    public class clsInteriorChecksData
    {


        public static bool GetInteriorInfoByID(int InteriorCheckID, ref bool SeatsOk, ref bool DashboardOk, ref bool OdorOk,
             ref string InteriorNotes)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM InteriorChecks WHERE InteriorCheckID=@InteriorCheckID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InteriorCheckID",InteriorCheckID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    SeatsOk = (bool)reader["SeatsOk"];
                    DashboardOk = (bool)reader["DashboardOk"];
                    OdorOk = (bool)reader["OdorOk"];

                    if (reader["InteriorNotes"] != DBNull.Value)
                        InteriorNotes = (string)reader["InteriorNotes"];
                    else
                        InteriorNotes = string.Empty;


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

        public static int AddNewInteriorCheck( bool SeatsOk,  bool DashboardOk,  bool OdorOk,
              string InteriorNotes)
        {
            int VehicleCheckID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Insert Into InteriorChecks
           (SeatsOk,DashboardOk,OdorOk,InteriorNotes)

            Values
           (@SeatsOk,@DashboardOk,@OdorOk,@InteriorNotes);
                           
                            SELECT SCOPE_IDENTITY();";



            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@SeatsOk", SeatsOk);
            command.Parameters.AddWithValue("@DashboardOk", DashboardOk);
            command.Parameters.AddWithValue("@OdorOk", OdorOk);
            if (InteriorNotes == "")
                command.Parameters.AddWithValue("@InteriorNotes", DBNull.Value);
            else
                command.Parameters.AddWithValue("@InteriorNotes", InteriorNotes);


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

        public static bool UpdateInteriorCheck(int InteriorCheckID, bool SeatsOk, bool DashboardOk, bool OdorOk,
              string InteriorNotes)
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            int AffectedRows = 0;

            string query = @"Update InteriorChecks
                           set SeatsOk=@SeatsOk,
                            DashboardOk=@DashboardOk,
                            OdorOk=@OdorOk,
                            InteriorNotes=@InteriorNotes
                
                      where InteriorCheckID=@InteriorCheckID;";



            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@SeatsOk", SeatsOk);
            command.Parameters.AddWithValue("@DashboardOk", DashboardOk);
            command.Parameters.AddWithValue("@OdorOk", OdorOk);
            if (InteriorNotes == "")
                command.Parameters.AddWithValue("@InteriorNotes", DBNull.Value);
            else
                command.Parameters.AddWithValue("@InteriorNotes", InteriorNotes);


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


        public static bool Delete(int InteriorCheckID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete InteriorChecks
                                where InteriorCheckID = @InteriorCheckID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InteriorCheckID", InteriorCheckID);

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
