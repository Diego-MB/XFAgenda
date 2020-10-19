using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using SQLite;
using UIKit;
using Xamarin.Forms;
using XFAgenda.Helpers;
using XFAgenda.iOS;

[assembly: Dependency(typeof(IOSSQLite))]
namespace XFAgenda.iOS
{
    class IOSSQLite : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder  
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder  
            var path = Path.Combine(libraryPath, DatabaseHelper.DbFileName);
            
            var conn = new SQLiteConnection(path);

            // Return the database connection  
            return conn;
        }
    }
}