using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_ADO.NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Contact contact = new Contact()
            {
                FirstName = "Rohan",
                LastName = "Shewale",
                Address = "location",
                City = "Mumbai",
                State = "Maharashtra",
                Zip = 400022,
                PhoneNumber = 9221581780,
                Email = "rohan@gmail.com"
            };
            AdressBook adressBook = new AdressBook();
  
            while (true)
            {
                Console.Write("1.Add Contact\n2.Get Contacts\nEnter a choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        adressBook.AddNewContactInDataBase(contact);
                        break;
                    case 2:
                        adressBook.GetAllContactsFromDatabase();
                        break;
                }
            }
            adressBook.AddNewContactInDataBase(contact);

            Console.ReadKey();

        }
    }
}
