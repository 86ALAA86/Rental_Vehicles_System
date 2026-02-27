using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_DataAccess_Layer
{
    public class clsExteriorCheckData
    {

        public static bool GetExteriorInfoByID(int ExteriorCheckID, ref bool LightsOk, ref bool PaintOk, ref bool MirrorsOk,
             ref bool TiresOk, ref bool WindowsOk, ref string ExteriorNotes)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM ExteriorChecks WHERE ExteriorCheckID=@ExteriorCheckID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ExteriorCheckID", ExteriorCheckID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                   LightsOk = (bool)reader["LightsOk"];
                    PaintOk = (bool)reader["PaintOk"];
                    MirrorsOk = (bool)reader["MirrorsOk"];
                    TiresOk = (bool)reader["TiresOk"];
                    WindowsOk = (bool)reader["WindowsOk"];

                    if(reader["ExteriorNotes"] != DBNull.Value)
                    ExteriorNotes = (string)reader["ExteriorNotes"];
                    else
                        ExteriorNotes = string.Empty;


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

        public static int AddNewExteriorCheck( bool LightsOk,  bool PaintOk,  bool MirrorsOk,
              bool TiresOk,  bool WindowsOk,  string ExteriorNotes)
        {
            int VehicleCheckID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Insert Into ExteriorChecks
           (LightsOk,PaintOk,MirrorsOk,TiresOk,WindowsOk,ExteriorNotes)

            Values
           (@LightsOk,@PaintOk,@MirrorsOk,@TiresOk,@WindowsOk,@ExteriorNotes);
                           
                            SELECT SCOPE_IDENTITY();";



            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LightsOk", LightsOk);
            command.Parameters.AddWithValue("@PaintOk", PaintOk);
            command.Parameters.AddWithValue("@MirrorsOk", MirrorsOk);
            command.Parameters.AddWithValue("@TiresOk", TiresOk);
            command.Parameters.AddWithValue("@WindowsOk", WindowsOk);

            if (ExteriorNotes == "")
                command.Parameters.AddWithValue("@ExteriorNotes", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ExteriorNotes", ExteriorNotes);


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

        public static bool UpdateExteriorCheck(int ExteriorCheckID, bool LightsOk, bool PaintOk, bool MirrorsOk,
              bool TiresOk, bool WindowsOk, string ExteriorNotes)
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            int AffectedRows = 0;

            string query = @"Update ExteriorChecks
                           set LightsOk=@LightsOk,
                            PaintOk=@PaintOk,
                            MirrorsOk=@MirrorsOk,
                            TiresOk=@TiresOk,
                            WindowsOk=@WindowsOk,
                            ExteriorNotes=@ExteriorNotes
                
                      where ExteriorCheckID=@ExteriorCheckID;";



            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LightsOk", LightsOk);
            command.Parameters.AddWithValue("@PaintOk", PaintOk);
            command.Parameters.AddWithValue("@MirrorsOk", MirrorsOk);
            command.Parameters.AddWithValue("@TiresOk", TiresOk);
            command.Parameters.AddWithValue("@WindowsOk", WindowsOk);

            if (ExteriorNotes == "")
                command.Parameters.AddWithValue("@ExteriorNotes", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ExteriorNotes", ExteriorNotes);



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

        public static bool Delete(int ExteriorCheckID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete ExteriorChecks
                                where ExteriorCheckID = @ExteriorCheckID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ExteriorCheckID", ExteriorCheckID);

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
