using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_DataAccess_Layer
{
    public class clsVehicleCheckData
    {
        public static bool GetVehicleCheckInfoByID(int VehicleCheckID, ref int ExteriorCheckID, ref int InteriorCheckID, ref int EngineCheckID, ref float FuelLevel, ref
        bool DamagedFound, ref string GeneralNotes, ref DateTime CheckDate,ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM VehicleCheck WHERE VehicleCheckID=@VehicleCheckID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@VehicleCheckID", VehicleCheckID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                   ExteriorCheckID = (int)reader["ExteriorCheckID"];
                    InteriorCheckID = (int)reader["InteriorCheckID"];
                    EngineCheckID = (int)reader["EngineCheckID"];
                    FuelLevel = float.Parse(reader["FuelLevel"].ToString());
                    DamagedFound = (bool)reader["DamagedFound"];

                    if (reader["GeneralNotes"] != DBNull.Value)
                        GeneralNotes = (string)reader["GeneralNotes"];
                    else
                        GeneralNotes = string.Empty;

                    CheckDate = (DateTime)reader["CheckDate"];
                    CreatedByUserID=(int)reader["CreatedByUserID"];


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

        public static int AddNewVehicleCheck(int ExteriorCheckID,   int InteriorCheckID,   int EngineCheckID,   float FuelLevel,  
        bool DamagedFound,   string GeneralNotes,   DateTime CheckDate,int CreatedByUserID)
        {
            int VehicleCheckID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Insert Into VehicleCheck 
           (ExteriorCheckID,InteriorCheckID,EngineCheckID,FuelLevel,
            DamagedFound,GeneralNotes,CheckDate,CreatedByUserID)

            Values
           (@ExteriorCheckID,@InteriorCheckID,@EngineCheckID
            ,@FuelLevel,@DamagedFound,@GeneralNotes,@CheckDate,@CreatedByUserID);
                           
                            SELECT SCOPE_IDENTITY();";



            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ExteriorCheckID", ExteriorCheckID);
            command.Parameters.AddWithValue("@InteriorCheckID", InteriorCheckID);
            command.Parameters.AddWithValue("@EngineCheckID", EngineCheckID);
            command.Parameters.AddWithValue("@FuelLevel", FuelLevel);
            command.Parameters.AddWithValue("@DamagedFound", DamagedFound);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            if(GeneralNotes =="")
            command.Parameters.AddWithValue("@GeneralNotes", DBNull.Value);
            else
                command.Parameters.AddWithValue("@GeneralNotes", GeneralNotes);

            command.Parameters.AddWithValue("@CheckDate", CheckDate);



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

        public static bool UpdateVehicleCheck(int VehicleCheckID,int ExteriorCheckID, int InteriorCheckID, int EngineCheckID, float FuelLevel,
        bool DamagedFound, string GeneralNotes, DateTime CheckDate, int CreatedByUserID)
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            int AffectedRows = 0;

            string query = @"Update VehicleCheck
                           set ExteriorCheckID=@ExteriorCheckID,
                            InteriorCheckID=@InteriorCheckID,
                            EngineCheckID=@EngineCheckID,
                            FuelLevel=@FuelLevel,
                            DamagedFound=@DamagedFound,
                            GeneralNotes=@GeneralNotes,
                            CheckDate=@CheckDate    
                       
                      where VehicleCheckID=@VehicleCheckID;";



            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ExteriorCheckID", ExteriorCheckID);
            command.Parameters.AddWithValue("@InteriorCheckID", InteriorCheckID);
            command.Parameters.AddWithValue("@EngineCheckID", EngineCheckID);
            command.Parameters.AddWithValue("@FuelLevel", FuelLevel);
            command.Parameters.AddWithValue("@DamagedFound", DamagedFound);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@VehicleCheckID", VehicleCheckID);

            if (GeneralNotes == "")
                command.Parameters.AddWithValue("@GeneralNotes", DBNull.Value);
            else
                command.Parameters.AddWithValue("@GeneralNotes", GeneralNotes);

            command.Parameters.AddWithValue("@CheckDate", CheckDate);



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

        public static bool IsVehicleCheckExist(int VehicleCheckID )
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM VehicleCheck WHERE VehicleCheckID = @VehicleCheckID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@VehicleCheckID", VehicleCheckID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

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

        public static bool Delete(int VehicleCheckID, int EngineCheckID
            , int ExteriorCheckID, int InteriorCheckID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete VehicleCheck 
                                where VehicleCheckID = @VehicleCheckID;
                      Delete EngineChecks where EngineCheckID=@EngineCheckID;
                      Delete ExteriorChecks where ExteriorCheckID=@ExteriorCheckID;
                      Delete InteriorChecks where InteriorCheckID=@InteriorCheckID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@VehicleCheckID", VehicleCheckID);
            command.Parameters.AddWithValue("@EngineCheckID", EngineCheckID);
            command.Parameters.AddWithValue("@ExteriorCheckID", ExteriorCheckID);
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
