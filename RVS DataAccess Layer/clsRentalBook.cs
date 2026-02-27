using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_DataAccess_Layer
{
    public class clsRentalBookData
    {

        public static DataTable GetAllRentalBooks()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from RentalBooking_View order by BookingID;";

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

        public static int AddNewRentalBook(int CustomerID, int VehicleID, DateTime RentalStartDate,
            DateTime RentalEndDate, string PickupLocation,string DropoffLocation,
            float RentalPricePerDay,int InitialCheckID,int CreatedByUserID)
        {
            //this function will return the new person id if succeeded and -1 if not.
            int BookID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO RentalBooking ( CustomerID,  VehicleID,  RentalStartDate,
             RentalEndDate,  PickupLocation, DropoffLocation,
             RentalPricePerDay, InitialCheckID, CreatedByUserID)
                             VALUES (@CustomerID, @VehicleID, @RentalStartDate,
@RentalEndDate, @PickupLocation, @DropoffLocation,
@RentalPricePerDay, @InitialCheckID, @CreatedByUserID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CustomerID", CustomerID);
            command.Parameters.AddWithValue("@VehicleID", VehicleID);
            command.Parameters.AddWithValue("@RentalStartDate", RentalStartDate);
            command.Parameters.AddWithValue("@RentalEndDate", RentalEndDate);
            command.Parameters.AddWithValue("@PickupLocation", PickupLocation);
            command.Parameters.AddWithValue("@DropoffLocation", DropoffLocation);
            command.Parameters.AddWithValue("@RentalPricePerDay", RentalPricePerDay);
            command.Parameters.AddWithValue("@InitialCheckID", InitialCheckID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    BookID = insertedID;
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

            return BookID;
        }


        public static bool UpdateRentalBook(int BookingID,int CustomerID, int VehicleID, DateTime RentalStartDate,
            DateTime RentalEndDate, string PickupLocation, string DropoffLocation,
            float RentalPricePerDay, int InitialCheckID, int CreatedByUserID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  RentalBooking  
                            set CustomerID = @CustomerID,
                            VehicleID = @VehicleID,
                            RentalStartDate = @RentalStartDate,
                            RentalEndDate = @RentalEndDate,
                            PickupLocation = @PickupLocation,
                            DropoffLocation = @DropoffLocation,
                            RentalPricePerDay = @RentalPricePerDay,
                            InitialCheckID = @InitialCheckID,
                            CreatedByUserID = @CreatedByUserID
                            where BookingID = @BookingID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BookingID", BookingID);
            command.Parameters.AddWithValue("@CustomerID", CustomerID);
            command.Parameters.AddWithValue("@VehicleID", VehicleID);
            command.Parameters.AddWithValue("@RentalStartDate", RentalStartDate);
            command.Parameters.AddWithValue("@RentalEndDate", RentalEndDate);
            command.Parameters.AddWithValue("@PickupLocation", PickupLocation);
            command.Parameters.AddWithValue("@DropoffLocation", DropoffLocation);
            command.Parameters.AddWithValue("@RentalPricePerDay", RentalPricePerDay);
            command.Parameters.AddWithValue("@InitialCheckID", InitialCheckID);
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

        public static bool GetRentalBookInfoByID(int BookingID,ref int CustomerID,ref int VehicleID,ref DateTime RentalStartDate,ref
            DateTime RentalEndDate,ref int InitialRentalDays,ref string PickupLocation,ref string DropoffLocation,ref
            float RentalPricePerDay,ref float InitialTotalDueAmount,ref int InitialCheckID,ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM RentalBooking Where BookingID=@BookingID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BookingID", BookingID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    CustomerID = Convert.ToInt32(reader["CustomerID"]);
                    VehicleID = Convert.ToInt32(reader["VehicleID"]);
                    RentalStartDate = Convert.ToDateTime(reader["RentalStartDate"]);
                    RentalEndDate = Convert.ToDateTime(reader["RentalEndDate"]);
                    PickupLocation = reader["PickupLocation"].ToString();
                    DropoffLocation = reader["DropoffLocation"].ToString();
                    RentalPricePerDay = float.Parse(reader["RentalPricePerDay"].ToString());
                    InitialCheckID = Convert.ToInt32(reader["InitialCheckID"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    InitialRentalDays = Convert.ToInt32(reader["InitialRentalDays"]);
                    InitialTotalDueAmount = float.Parse(reader["InitialTotalDueAmount"].ToString());



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

        public static bool DeleteRentalBooking(int BookID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete RentalBooking 
                                where BookingID = @BookingID";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@BookingID", BookID);
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

        public static bool IsBookingExists(int BookingID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM RentalBooking WHERE BookingID = @BookingID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BookingID", BookingID);

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

        public static bool IsBookingReturned(int BookingID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM VehicleReturns WHERE BookingID = @BookingID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BookingID", BookingID);

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
