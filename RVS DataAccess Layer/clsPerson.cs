using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_DataAccess_Layer
{
    public class clsPersonData
    {

        public static bool GetPersonInfoByID(int PersonID, ref string FirstName, ref string LastName,
            ref string Email,ref string Address,ref string Phone,ref byte Gender,ref string NationalNumber,
            ref DateTime DateOfBirth,ref int CreatedByUserID,ref int NationalityID,ref string ImagePath
          )
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM People WHERE PersonID = @PersonID";

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

                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];

                    NationalNumber = (string)reader["NationalNumber"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];

                    Gender = (byte)reader["Gender"];
                    Address = (string)reader["Address"];

                    Phone = (string)reader["Phone"];
                    Email = (string)reader["Email"];

                    NationalityID = (int)reader["NationalityID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    //ImagePath: allows null in database so we should handle null
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }

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


        public static bool GetPersonInfoByNationalNo(string NationalNumber,ref int PersonID, ref string FirstName, ref string LastName,
            ref string Email, ref string Address, ref string Phone, ref byte Gender, 
            ref DateTime DateOfBirth, ref int CreatedByUserID, ref int NationalityID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM People WHERE NationalNumber = @NationalNumber";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNumber", NationalNumber);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];

                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    PersonID = (int)reader["PersonID"];


                    Gender = (byte)reader["Gender"];
                    Address = (string)reader["Address"];

                    Phone = (string)reader["Phone"];
                    Email = (string)reader["Email"];

                    NationalityID = (int)reader["NationalityID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    //ImagePath: allows null in database so we should handle null
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }


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



        public static int AddNewPerson( string FirstName,  string LastName,
             string Email,  string Address,  string Phone,  byte Gender,  string NationalNumber,
             DateTime DateOfBirth,  int CreatedByUserID,  int NationalityID,  string ImagePath)
        {
            //this function will return the new person id if succeeded and -1 if not.
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO People
                (  FirstName,   LastName,
              Email,   Address,   Phone,  Gender,   NationalNumber,
              DateOfBirth,   CreatedByUserID,   NationalityID,   ImagePath)

                             VALUES
                (@FirstName, @LastName, @Email, @Address, @Phone, @Gender, @NationalNumber,
@DateOfBirth, @CreatedByUserID, @NationalityID, @ImagePath);

                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);

            command.Parameters.AddWithValue("@NationalNumber", NationalNumber);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);

            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Address", Address);

            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);
          
            command.Parameters.AddWithValue("@NationalityID", NationalityID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            if (ImagePath != "" && ImagePath != null)
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    PersonID = insertedID;
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

            return PersonID;
        }

        

        public static bool UpdatePerson(int PersonID, string FirstName, string LastName,
             string Email, string Address, string Phone, byte Gender, string NationalNumber,
             DateTime DateOfBirth, int CreatedByUserID, int NationalityID, string ImagePath)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  People  
                            set FirstName = @FirstName,
                                LastName = @LastName,                               
                                NationalNumber = @NationalNumber,
                                DateOfBirth = @DateOfBirth,
                                Gender=@Gender,
                                Address = @Address,  
                                Phone = @Phone,
                                Email = @Email, 
                                CreatedByUserID=@CreatedByUserID,
                                NationalityID = @NationalityID,
                                ImagePath =@ImagePath
                                where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);


            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);

            command.Parameters.AddWithValue("@NationalNumber", NationalNumber);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);

            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Address", Address);

            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);

            command.Parameters.AddWithValue("@NationalityID", NationalityID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            if (ImagePath != "" && ImagePath != null)
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);


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


        public static DataTable GetAllPeople()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from People_View order by FirstName;";

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

        public static bool DeletePerson(int PersonID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete People 
                                 where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

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

        public static bool IsPersonExist(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM People WHERE PersonID = @PersonID";

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

        public static bool IsPersonExist(string NationalNo)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM People WHERE NationalNumber = @NationalNo";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

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
