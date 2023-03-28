using System;
using System.Data;
using System.Data.SqlClient;

namespace AddressBook_ADO.NET
{
    public class AdressBook
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBook_Service";

        public void AddNewContactInDataBase(Contact contact)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                using (connection)
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("SpAddingNewData", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@FirstName", contact.FirstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", contact.LastName);
                    sqlCommand.Parameters.AddWithValue("@Address", contact.Address);
                    sqlCommand.Parameters.AddWithValue("@City", contact.City);
                    sqlCommand.Parameters.AddWithValue("@State", contact.State);
                    sqlCommand.Parameters.AddWithValue("@Zip", contact.Zip);
                    sqlCommand.Parameters.AddWithValue("@PhoneNUmber", contact.PhoneNUmber);
                    sqlCommand.Parameters.AddWithValue("@Email", contact.Email);

                    int result = sqlCommand.ExecuteNonQuery();
                    connection.Close();
                    if (result >= 1)
                        Console.WriteLine("New Contact added.");
                    else
                        Console.WriteLine("Error");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
