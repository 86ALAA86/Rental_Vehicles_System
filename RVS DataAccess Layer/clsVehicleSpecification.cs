using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_DataAccess_Layer
{
    public class clsVehicleSpecificationData
    {

        public static DataTable GetAllVehiclesSpecification()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM VehicleSpecifications order by VehicleSpecificationID";

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


        public static int AddNewVehicleSpecification(int MakeID,int FuelTypeID,int AspirationID,
            int BodyID,int CylinderTypeID,int EngineBlockTypeID,int EngineID,int DriveTypeID,string HexColor)
        {
            int VehicleID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Insert Into VehicleSpecifications 
           ( MakeID, FuelTypeID, AspirationID,
             BodyID, CylinderTypeID, EngineBlockTypeID, EngineID, DriveTypeID,HexColor)

            Values
           ( @MakeID,@FuelTypeID,@AspirationID,@BodyID,
          @CylinderTypeID,@EngineBlockTypeID,@EngineID,@DriveTypeID,@HexColor);
                           
                            SELECT SCOPE_IDENTITY();";



            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@MakeID", MakeID);
            command.Parameters.AddWithValue("@FuelTypeID", FuelTypeID);
            command.Parameters.AddWithValue("@AspirationID", AspirationID);
            command.Parameters.AddWithValue("@BodyID", BodyID);
            command.Parameters.AddWithValue("@CylinderTypeID", CylinderTypeID);
            command.Parameters.AddWithValue("@EngineBlockTypeID", EngineBlockTypeID);
            command.Parameters.AddWithValue("@EngineID", EngineID);
            command.Parameters.AddWithValue("@DriveTypeID", DriveTypeID);
            command.Parameters.AddWithValue("@HexColor", HexColor);



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    VehicleID = insertedID;
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


            return VehicleID;

        }

        public static bool UpdateVehicleSpecification(int VehicleSpecificationID,int MakeID, int FuelTypeID, int AspirationID,
            int BodyID, int CylinderTypeID, int EngineBlockTypeID, int EngineID, int DriveTypeID,string HexColor)
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            int AffectedRows = 0;

            string query = @"Update VehicleSpecifications 
                           set MakeID=@MakeID,
                            FuelTypeID=@FuelTypeID,
                            AspirationID=@AspirationID,
                            BodyID=@BodyID,
                            CylinderTypeID=@CylinderTypeID,
                            EngineBlockTypeID=@EngineBlockTypeID,
                            EngineID=@EngineID,
                            DriveTypeID=@DriveTypeID
                            HexColor=@HexColor

                      where VehicleSpecificationID=@VehicleSpecificationID;";



            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@MakeID", MakeID);
            command.Parameters.AddWithValue("@FuelTypeID", FuelTypeID);
            command.Parameters.AddWithValue("@AspirationID", AspirationID);
            command.Parameters.AddWithValue("@BodyID", BodyID);
            command.Parameters.AddWithValue("@CylinderTypeID", CylinderTypeID);
            command.Parameters.AddWithValue("@EngineBlockTypeID", EngineBlockTypeID);
            command.Parameters.AddWithValue("@EngineID", EngineID);
            command.Parameters.AddWithValue("@DriveTypeID", DriveTypeID);
            command.Parameters.AddWithValue("@HexColor", HexColor);


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

        public static bool Delete(int VehicleSpecificationID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete VehicleSpecifications 
                                where VehicleSpecificationID = @VehicleSpecificationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@VehicleSpecificationID", VehicleSpecificationID);

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

        public static bool GetSpecificationInfoByID(int VehicleSpecificationID,ref int MakeID,ref int FuelTypeID,ref int AspirationID,ref
            int BodyID,ref int CylinderTypeID,ref int EngineBlockTypeID,ref int EngineID,ref int DriveTypeID,ref string HexColor)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM VehicleSpecifications WHERE VehicleSpecificationID=@VehicleSpecificationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@VehicleSpecificationID", VehicleSpecificationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    MakeID = (int)reader["MakeID"];
                    FuelTypeID = (int)reader["FuelTypeID"];
                    AspirationID = (byte)reader["AspirationID"];
                    BodyID = (int)reader["BodyID"];
                    CylinderTypeID = (int)reader["CylinderTypeID"];
                    EngineBlockTypeID = (int)reader["EngineBlockTypeID"];
                    EngineID = (int)reader["EngineID"];
                    DriveTypeID = (int)reader["DriveTypeID"];
                    HexColor = reader["HexColor"].ToString();

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



        public static bool IsVehicleSpecificationsExist(int VehicleSpecificationsID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM VehicleSpecifications WHERE VehicleSpecificationsID = @VehicleSpecificationsID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@VehicleSpecificationsID", VehicleSpecificationsID);

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


    }
}
