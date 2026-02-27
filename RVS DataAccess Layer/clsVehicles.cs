using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace RVS_DataAccess_Layer
{
    public class clsVehiclesData
    {

        public static DataTable GetAllVehicles()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from Vehicles_View order by VehicleID";

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

        public static DataTable GetAllVehicleMaintenances(int VehicleID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select * from Maintenance where VehicleID=@VehicleID ;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("VehicleID", VehicleID);

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


        public static int AddNewVehicle(string Model,string Year,int Mileage,string PlateNumber,
            float RentalPricePerDay,bool IsAvailableForRent,int CreatedByUserID,int VehicleSpecificationID,
            int CurrentCheckID)
        {
            int VehicleID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Insert Into Vehicle 
           ( Model,Year,Mileage,PlateNumber,RentalPricePerDay,
            IsAvailableForRent,CreatedByUserID,VehicleSpecificationID,
            CurrentCheckID)

            Values
           (@Model,@Year,@Mileage,@PlateNumber,@RentalPricePerDay,
            @IsAvailableForRent,@CreatedByUserID,@VehicleSpecificationID,
            @CurrentCheckID);
                           
                            SELECT SCOPE_IDENTITY();";



            SqlCommand command = new SqlCommand(query, connection);

           command.Parameters.AddWithValue("@Model", Model);
           command.Parameters.AddWithValue("@Year", Year);
           command.Parameters.AddWithValue("@Mileage", Mileage);
           command.Parameters.AddWithValue("@PlateNumber", PlateNumber);
           command.Parameters.AddWithValue("@RentalPricePerDay", RentalPricePerDay);
           command.Parameters.AddWithValue("@IsAvailableForRent", IsAvailableForRent);
           command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
           command.Parameters.AddWithValue("@VehicleSpecificationID", VehicleSpecificationID);
           command.Parameters.AddWithValue("@CurrentCheckID", CurrentCheckID);



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

        public static bool UpdateVehicle(int VehicleID,string Model, string Year, int Mileage, string PlateNumber,
          float RentalPricePerDay, bool IsAvailableForRent, int CreatedByUserID, int VehicleSpecificationID,
          int CurrentCheckID)
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            int AffectedRows = 0;

            string query = @"Update Vehicle 
                           set Model=@Model,
                      Year=@Year,Mileage=@Mileage,PlateNumber=@PlateNumber,
                      RentalPricePerDay=@RentalPricePerDay,
                      IsAvailableForRent=@IsAvailableForRent
                      ,CreatedByUserID=@CreatedByUserID,
                      VehicleSpecificationID=@VehicleSpecificationID
                      ,CurrentCheckID=@CurrentCheckID 
                      where VehicleID=@VehicleID;";



            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Model", Model);
            command.Parameters.AddWithValue("@VehicleID", VehicleID);
            command.Parameters.AddWithValue("@Year", Year);
            command.Parameters.AddWithValue("@Mileage", Mileage);
            command.Parameters.AddWithValue("@PlateNumber", PlateNumber);
            command.Parameters.AddWithValue("@RentalPricePerDay", RentalPricePerDay);
            command.Parameters.AddWithValue("@IsAvailableForRent", IsAvailableForRent);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@VehicleSpecificationID", VehicleSpecificationID);
            command.Parameters.AddWithValue("@CurrentCheckID", CurrentCheckID);



            try
            {
                connection.Open();

                AffectedRows=command.ExecuteNonQuery();
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


            return (AffectedRows>0);

        }

        public static bool RentVehicle(int VehicleID)
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            int AffectedRows = 0;

            string query = @"Update Vehicle 
                           set 
                      IsAvailableForRent=0
                     
                      where VehicleID=@VehicleID;";



            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@VehicleID", VehicleID);
          
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

        public static bool DeleteVehicle(int VehicleID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Vehicles 
                                where VehicleID = @VehicleID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@VehicleID",VehicleID);

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

        public static bool GetVehicleInfoByID(int VehicleID,ref  string Model,ref  string Year,ref  int Mileage,ref  string PlateNumber,ref 
          float RentalPricePerDay,ref  bool IsAvailableForRent,ref  int CreatedByUserID,ref  int VehicleSpecificationID,ref 
          int CurrentCheckID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Vehicle WHERE VehicleID=@VehicleID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@VehicleID",VehicleID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    Model=(string)reader["Model"];
                    Year = (string)reader["Year"];
                    Mileage = (int)reader["Mileage"];
                    PlateNumber = (string)reader["PlateNumber"];
                    RentalPricePerDay = float.Parse(reader["RentalPricePerDay"].ToString());
                    IsAvailableForRent = (bool)reader["IsAvailableForRent"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    VehicleSpecificationID = (int)reader["VehicleSpecificationID"];
                    CurrentCheckID = (int)reader["CurrentCheckID"];

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

        public static bool IsVehicleExist(int VehicleID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Vehicle WHERE VehicleID = @VehicleID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@VehicleID", VehicleID);

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
