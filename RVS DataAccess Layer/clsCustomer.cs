using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_DataAccess_Layer
{
    public class clsCustomerData

    {

        public static bool GetCustomerInfoByCustomerID(int CustomerID, ref int PersonID, ref string DriverLicenseNumber,
            ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Customer WHERE CustomerID = @CustomerID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CustomerID", CustomerID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    DriverLicenseNumber = (string)reader["DriverLicenseNumber"];
                    CreatedByUserID= (int)reader["CreatedByUserID"];


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


        public static bool GetCustomerInfoByDriverLicenseNumber(string DriverLicenseNumber, ref int CustomerID, ref int PersonID, 
           ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Customer WHERE DriverLicenseNumber = @DriverLicenseNumber";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverLicenseNumber", DriverLicenseNumber);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    CustomerID = (int)reader["CustomerID"];
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


        public static bool GetCustomerInfoByPersonID( int PersonID,ref int CustomerID, ref string DriverLicenseNumber,
            ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Customer WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    CustomerID = (int)reader["CustomerID"];
                    DriverLicenseNumber = (string)reader["DriverLicenseNumber"];
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

    
        public static int AddNewCustomer(int PersonID,  string DriverLicenseNumber,
             int CreatedByUserID)
        {
            //this function will return the new person id if succeeded and -1 if not.
            int CustomerID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Customer (PersonID, DriverLicenseNumber,
              CreatedByUserID)
                             VALUES (@PersonID,@DriverLicenseNumber,
              @CreatedByUserID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@DriverLicenseNumber", DriverLicenseNumber);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    CustomerID = insertedID;
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

            return CustomerID;
        }


        public static bool UpdateCustomer(int CustomerID,int PersonID, string DriverLicenseNumber,
             int CreatedByUserID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Customer  
                            set PersonID = @PersonID,
                                CreatedByUserID = @CreatedByUserID,
                                DriverLicenseNumber=@DriverLicenseNumber 
                                where CustomerID=@CustomerID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@DriverLicenseNumber", DriverLicenseNumber);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@CustomerID", CustomerID);



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

        public static DataTable GetAllCustomer()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Customers_View order by CustomerID;";

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

        public static bool DeleteCustomer(int CustomerID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Customer 
                                where CustomerID = @CustomerID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CustomerID", CustomerID);

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

        public static bool IsCustomerExistByCustomerID(int CustomerID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Customer WHERE CustomerID = @CustomerID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CustomerID", CustomerID);

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

        public static bool IsCustomerExistByPersonID(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Customer WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

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

        public static bool IsCustomerExistByDriverLicenseNumber(string DriverLicenseNumber)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Customer WHERE DriverLicenseNumber = @DriverLicenseNumber";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverLicenseNumber", DriverLicenseNumber);

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

        public static DataTable GetAllCustomerBooks(int CustomerID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from RentalBooking_View Where CustomerID=@CustomerID order by BookingID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CustomerID", CustomerID);

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


    }
}
