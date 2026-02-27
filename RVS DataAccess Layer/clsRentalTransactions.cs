using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_DataAccess_Layer
{
    public class clsRentalTransactionsData
    {

        public static DataTable GetAllRentalTransaction()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select * from RentalTransaction ;";

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

        public static int AddNewRentalTransaction(int BookingID,int ReturnID,
            string PaymentNotes,float InitialPaidAmount,float ActualDueAmount,
            float TotalRemaining,float TotalRefundedAmount,DateTime TransactionDate,
            DateTime UpdatedTransactionDate,int CreatedByUserID,int PaymentMethodID)
        {
            //this function will return the new person id if succeeded and -1 if not.
            int TransactionID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO RentalTransaction ( BookingID, ReturnID,
             PaymentNotes, PaidInitialTotalDueAmount, ActualTotalDueAmount,
             TotalRemaining, TotalRefundedAmount, TransactionDate,
             UpdatedTransactionDate, CreatedByUserID, PaymentMethodID)
                             VALUES (@BookingID,@ReturnID,
                        @PaymentNotes,@PaidInitialTotalDueAmount,@ActualTotalDueAmount,
                        @TotalRemaining,@TotalRefundedAmount,@TransactionDate,
                        @UpdatedTransactionDate,@CreatedByUserID,@PaymentMethodID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BookingID", BookingID);

            if(ReturnID==-1)
            command.Parameters.AddWithValue("@ReturnID", DBNull.Value);
            else
            command.Parameters.AddWithValue("@ReturnID", ReturnID);


            command.Parameters.AddWithValue("@PaymentNotes", PaymentNotes);
            command.Parameters.AddWithValue("@PaidInitialTotalDueAmount", InitialPaidAmount);
            command.Parameters.AddWithValue("@ActualTotalDueAmount", ActualDueAmount);
            command.Parameters.AddWithValue("@TotalRemaining", TotalRemaining);
            command.Parameters.AddWithValue("@TransactionDate", TransactionDate);
            command.Parameters.AddWithValue("@TotalRefundedAmount", TotalRefundedAmount);


            if (UpdatedTransactionDate==DateTime.MinValue)
            command.Parameters.AddWithValue("@UpdatedTransactionDate", DBNull.Value);
            else
            command.Parameters.AddWithValue("@UpdatedTransactionDate", UpdatedTransactionDate);

            command.Parameters.AddWithValue("@PaymentMethodID", PaymentMethodID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TransactionID = insertedID;
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

            return TransactionID;
        }


        public static bool UpdateTransaction(int TransactionID, int BookingID, int ReturnID,
            string PaymentNotes, float InitialPaidAmount, float ActualDueAmount,
            float TotalRemaining, float TotalRefundedAmount, DateTime TransactionDate,
            DateTime UpdatedTransactionDate, int CreatedByUserID, int PaymentMethodID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  RentalTransaction 
                            set
                               BookingID=@BookingID,
                         ReturnID=@ReturnID,
                         PaymentNotes=@PaymentNotes,
                         PaidInitialTotalDueAmount=@PaidInitialTotalDueAmount,
                         ActualTotalDueAmount=@ActualTotalDueAmount,
                         TotalRemaining=@TotalRemaining,
                         TotalRefundedAmount=@TotalRefundedAmount,
                         TransactionDate=@TransactionDate,
                         UpdatedTransactionDate=@UpdatedTransactionDate,
                         CreatedByUserID=@CreatedByUserID,
                         PaymentMethodID=@PaymentMethodID
                            where TransactionID = @TransactionID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BookingID", BookingID);
            command.Parameters.AddWithValue("@TransactionID", TransactionID);


            if (ReturnID == -1)
                command.Parameters.AddWithValue("@ReturnID", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ReturnID", ReturnID);


            command.Parameters.AddWithValue("@PaymentNotes", PaymentNotes);
            command.Parameters.AddWithValue("@TotalRefundedAmount", TotalRefundedAmount);

            command.Parameters.AddWithValue("@PaidInitialTotalDueAmount", InitialPaidAmount);
            command.Parameters.AddWithValue("@ActualTotalDueAmount", ActualDueAmount);
            command.Parameters.AddWithValue("@TotalRemaining", TotalRemaining);
            command.Parameters.AddWithValue("@TransactionDate", TransactionDate);

            if (UpdatedTransactionDate == DateTime.MinValue)
                command.Parameters.AddWithValue("@UpdatedTransactionDate", DBNull.Value);
            else
                command.Parameters.AddWithValue("@UpdatedTransactionDate", UpdatedTransactionDate);

            command.Parameters.AddWithValue("@PaymentMethodID", PaymentMethodID);
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

        public static bool PayRefurnds(int TransactionID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  RentalTransaction 
                            set
                         TotalRefundedAmount= ABS(TotalRemaining),
                         TotalRemaining=0
                         
                            where TransactionID = @TransactionID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TransactionID", TransactionID);   
           


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

        public static bool IsRefunded(int TransactionID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT TotalRefundedAmount FROM RentalTransaction WHERE TransactionID = @TransactionID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TransactionID", TransactionID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && float.TryParse(result.ToString(), out float refunded))
                {
                    isFound = (refunded != 0);
                }
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


        public static bool GetTransactionInfoByTransctionID(int TransactionID,ref int BookingID,ref int ReturnID,ref
            string PaymentNotes,ref float InitialPaidAmount,ref float ActualDueAmount,ref
            float TotalRemaining,ref float TotalRefundedAmount,ref DateTime TransactionDate,ref
            DateTime UpdatedTransactionDate,ref int CreatedByUserID,ref int PaymentMethodID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM RentalTransaction Where TransactionID=@TransactionID ;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TransactionID", TransactionID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    BookingID = Convert.ToInt32(reader["BookingID"]);
                    ReturnID = Convert.ToInt32(reader["ReturnID"]);
                    TransactionDate = Convert.ToDateTime(reader["TransactionDate"]);
                    UpdatedTransactionDate = Convert.ToDateTime(reader["UpdatedTransactionDate"]);
                    PaymentNotes = reader["PaymentNotes"].ToString();
                    InitialPaidAmount = float.Parse(reader["PaidInitialTotalDueAmount"].ToString());
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    PaymentMethodID = Convert.ToInt32(reader["PaymentMethodID"]);
                    ActualDueAmount = float.Parse(reader["ActualTotalDueAmount"].ToString());

                    TotalRemaining = float.Parse(reader["TotalRemaining"].ToString());
                    TotalRefundedAmount = float.Parse(reader["TotalRefundedAmount"].ToString());



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

        public static bool GetTransactionInfoByBookingID(int BookingID,ref int TransactionID , ref int ReturnID, ref
           string PaymentNotes, ref float InitialPaidAmount, ref float ActualDueAmount, ref
           float TotalRemaining, ref float TotalRefundedAmount, ref DateTime TransactionDate, ref
           DateTime UpdatedTransactionDate, ref int CreatedByUserID, ref int PaymentMethodID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM RentalTransaction Where BookingID=@BookingID ;";

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

                    TransactionID = Convert.ToInt32(reader["TransactionID"]);

                    if (reader["ReturnID"] != DBNull.Value)
                        ReturnID = Convert.ToInt32(reader["ReturnID"]);
                    else
                        ReturnID = -1; 

                    TransactionDate = Convert.ToDateTime(reader["TransactionDate"]);

                    if (reader["UpdatedTransactionDate"] != DBNull.Value)
                        UpdatedTransactionDate = Convert.ToDateTime(reader["UpdatedTransactionDate"]);
                    else
                        UpdatedTransactionDate = DateTime.MinValue.Date;




                    PaymentNotes = reader["PaymentNotes"].ToString();
                    InitialPaidAmount = float.Parse(reader["PaidInitialTotalDueAmount"].ToString());
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    PaymentMethodID = Convert.ToInt32(reader["PaymentMethodID"]);
                    ActualDueAmount = float.Parse(reader["ActualTotalDueAmount"].ToString());

                    TotalRemaining = float.Parse(reader["TotalRemaining"].ToString());
                    TotalRefundedAmount = float.Parse(reader["TotalRefundedAmount"].ToString());



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

        public static bool GetTransactionInfoReturnID( int ReturnID, ref int TransactionID, ref int BookingID,  ref
            string PaymentNotes, ref float InitialPaidAmount, ref float ActualDueAmount, ref
            float TotalRemaining, ref float TotalRefundedAmount, ref DateTime TransactionDate, ref
            DateTime UpdatedTransactionDate, ref int CreatedByUserID, ref int PaymentMethodID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM RentalTransaction Where ReturnID=@ReturnID ;";

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

                    TransactionID = Convert.ToInt32(reader["TransactionID"]);
                    BookingID = Convert.ToInt32(reader["BookingID"]);
                    TransactionDate = Convert.ToDateTime(reader["TransactionDate"]);
                    UpdatedTransactionDate = Convert.ToDateTime(reader["UpdatedTransactionDate"]);
                    PaymentNotes = reader["PaymentNotes"].ToString();
                    InitialPaidAmount = float.Parse(reader["PaidInitialTotalDueAmount"].ToString());
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    PaymentMethodID = Convert.ToInt32(reader[" PaymentMethodID"]);
                    ActualDueAmount = float.Parse(reader["ActualTotalDueAmount"].ToString());

                    TotalRemaining = float.Parse(reader["TotalRemaining"].ToString());
                    TotalRefundedAmount = float.Parse(reader["TotalRefundedAmount"].ToString());



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

        public static bool DeleteTransaction(int TransactionID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete RentalTransaction 
                                where TransactionID = @TransactionID";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@TransactionID", TransactionID);
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
