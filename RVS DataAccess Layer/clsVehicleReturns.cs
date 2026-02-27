using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_DataAccess_Layer
{
    public class clsVehicleReturnsData
    {

        public static DataTable GetAllReturnedVehicles()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Returns_View order by ActualReturnDate desc;";

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

        public static int AddNewVehicleReturn(DateTime ActualReturnDate,byte ActualRentalDays,
            int Mileage,int ConsumedMileage,string ReturnNotes,float AdditionalCharges,
            float ActualTotalDueAmount,int CreatedByUserID,int ReturnCheckID,int BookingID)
        {
            //this function will return the new person id if succeeded and -1 if not.
            int ReturnID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO VehicleReturns ( ActualReturnDate, ActualRentalDays,
             Mileage, ConsumedMileage, ReturnNotes, AdditionalCharges,
             ActualTotalDueAmount, CreatedByUserID, ReturnCheckID, BookingID)
                             VALUES (@ActualReturnDate,@ActualRentalDays,@Mileage
             ,@ConsumedMileage,@ReturnNotes,@AdditionalCharges,
             @ActualTotalDueAmount,@CreatedByUserID,@ReturnCheckID,@BookingID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ActualReturnDate", ActualReturnDate);
            command.Parameters.AddWithValue("@ActualRentalDays", ActualRentalDays);
            command.Parameters.AddWithValue("@Mileage", Mileage);
            command.Parameters.AddWithValue("@ConsumedMileage", ConsumedMileage);
            command.Parameters.AddWithValue("@ReturnNotes", ReturnNotes);
            command.Parameters.AddWithValue("@AdditionalCharges", AdditionalCharges);
            command.Parameters.AddWithValue("@ActualTotalDueAmount", ActualTotalDueAmount);
            command.Parameters.AddWithValue("@ReturnCheckID", ReturnCheckID);
            command.Parameters.AddWithValue("@BookingID", BookingID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ReturnID = insertedID;
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

            return ReturnID;
        }


        public static bool UpdateVehicleReturn(int ReturnID,DateTime ActualReturnDate, byte ActualRentalDays,
            int Mileage, int ConsumedMileage, string ReturnNotes, float AdditionalCharges,
            float ActualTotalDueAmount, int CreatedByUserID, int ReturnCheckID, int BookingID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  VehicleReturns  
                            set 
                            ActualReturnDate=@ActualReturnDate,
                            ActualRentalDays=@ActualRentalDays,
                            Mileage=@Mileage,
                            ConsumedMileage=@ConsumedMileage,
                            ReturnNotes=@ReturnNotes,
                            AdditionalCharges=@AdditionalCharges,
                            ActualTotalDueAmount=@ActualTotalDueAmount,
                            CreatedByUserID=@CreatedByUserID,
                            ReturnCheckID=@ReturnCheckID,
                            BookingID=@BookingID

                            where ReturnID = @ReturnID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ActualReturnDate", ActualReturnDate);
            command.Parameters.AddWithValue("@ActualRentalDays", ActualRentalDays);
            command.Parameters.AddWithValue("@Mileage", Mileage);
            command.Parameters.AddWithValue("@ConsumedMileage", ConsumedMileage);
            command.Parameters.AddWithValue("@ReturnNotes", ReturnNotes);
            command.Parameters.AddWithValue("@AdditionalCharges", AdditionalCharges);
            command.Parameters.AddWithValue("@ActualTotalDueAmount", ActualTotalDueAmount);
            command.Parameters.AddWithValue("@ReturnCheckID", ReturnCheckID);
            command.Parameters.AddWithValue("@BookingID", BookingID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@ReturnID", ReturnID);

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

        public static bool GetVehicleReturnInfoByID(int ReturnID,ref DateTime ActualReturnDate,ref byte ActualRentalDays,ref
            int Mileage,ref int ConsumedMileage,ref string ReturnNotes,ref float AdditionalCharges,ref
            float ActualTotalDueAmount,ref int CreatedByUserID,ref int ReturnCheckID,ref int BookingID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM VehicleReturns Where ReturnID=@ReturnID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ReturnID", ReturnID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    ActualRentalDays = Convert.ToByte(reader["ActualRentalDays"]);
                    Mileage = Convert.ToInt32(reader["Mileage"]);
                    ActualReturnDate = Convert.ToDateTime(reader["ActualReturnDate"]);
                    ActualReturnDate = Convert.ToDateTime(reader["ActualReturnDate"]);
                    ReturnNotes = reader["ReturnNotes"].ToString();
                    AdditionalCharges = float.Parse(reader["AdditionalCharges"].ToString());
                    ConsumedMileage = Convert.ToInt32(reader["ConsumedMileage"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    ReturnCheckID = Convert.ToInt32(reader["ReturnCheckID"]);
                    BookingID = Convert.ToInt32(reader["BookingID"]);
                    ActualTotalDueAmount = float.Parse(reader["ActualTotalDueAmount"].ToString());

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

        public static bool DeleteVehicleReturn(int VehicleRetrunID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete VehicleReturns 
                                where RetrunID = @RetrunID";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@RetrunID",VehicleRetrunID);
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

        public static bool IsReturnFinished(int ReturnID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM RentalTransaction WHERE ReturnID = @ReturnID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ReturnID", ReturnID);

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
