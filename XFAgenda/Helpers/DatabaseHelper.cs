using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using XFAgenda.Models;

namespace XFAgenda.Helpers
{
    public class DatabaseHelper
    {
        static SQLiteConnection connection;
        public const string DbFileName = "Contacts.db3";

        public DatabaseHelper()
        {
            connection = DependencyService.Get<ISQLite>().GetConnection();
            connection.CreateTable<ContactInfo>();
        }

        // Get All Contact data      
        public List<ContactInfo> GetAllContactsData()
        {
            return (from data in connection.Table<ContactInfo>()
                    select data).ToList();
        }

        //Get Specific Contact data  
        public ContactInfo GetContactData(int id)
        {
            return connection.Table<ContactInfo>().FirstOrDefault(t => t.Id == id);
        }

        // Delete all Contacts Data  
        public void DeleteAllContacts()
        {
            connection.DeleteAll<ContactInfo>();
        }

        // Delete Specific Contact  
        public void DeleteContact(int id)
        {
            connection.Delete<ContactInfo>(id);
        }

        // Insert new Contact to DB   
        public void InsertContact(ContactInfo contact)
        {
            connection.Insert(contact);
        }

        // Update Contact Data  
        public void UpdateContact(ContactInfo contact)
        {
            connection.Update(contact);
        }
    }
}
