using System;
using System.Collections.Generic;
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
                    sqlCommand.Parameters.AddWithValue("@PhoneNUmber", contact.PhoneNumber);
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
        public void GetAllContactsFromDatabase()
        {
            SqlConnection connection = new SqlConnection(connectionString);


            List<Contact> contacts = new List<Contact>();
            using (connection)
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("SpGetAllData", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader sqlReader = sqlCommand.ExecuteReader();
                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        Contact contact = new Contact()
                        {
                            FirstName = sqlReader.GetString(0),
                            LastName = sqlReader.GetString(1),
                            Address = sqlReader.GetString(2),
                            City = sqlReader.GetString(3),
                            State = sqlReader.GetString(4),
                            Zip = sqlReader.GetInt32(5),
                            PhoneNumber = sqlReader.GetInt64(6),
                            Email = sqlReader.GetString(7)
                        };
                        contacts.Add(contact);
                    }
                    foreach (var contact in contacts)
                    {
                        Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                        Console.WriteLine($"Address: {contact.Address}, {contact.City}, {contact.State}, {contact.Zip}");
                        Console.WriteLine($"Phone: {contact.PhoneNumber}, Email: {contact.Email}");
                    }
                }
                else
                {
                    Console.WriteLine("There is no data");
                }
            }

        }
        public void DeleteContact(string firstName, string lastName)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                using (connection)
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("SpDeleteByFirstLastName", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@FirstName", firstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", lastName);
                    int result = sqlCommand.ExecuteNonQuery();
                    connection.Close();
                    if (result >= 1)
                        Console.WriteLine("Contact deleted");
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
