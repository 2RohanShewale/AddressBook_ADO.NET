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
                PhoneNUmber = 9221581780,
                Email = "rohan@gmail.com"
            };
            AdressBook adressBook = new AdressBook();

            adressBook.AddNewContactInDataBase(contact);

            Console.ReadKey();

        }
    }
}
