using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using Xamarin.Forms;
using XFAgenda.Droid;
using XFAgenda.Helpers;

[assembly: Dependency(typeof(AndroidSQLite))]
namespace XFAgenda.Droid
{
    class AndroidSQLite : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            // Documents folder  
            var path = Path.Combine(documentsPath, DatabaseHelper.DbFileName);
            var conn = new SQLiteConnection(path);

            // Return the database connection  
            return conn;
        }
    }
}