using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using SQLITE.Droid;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(SqliteClient))]

namespace SQLITE.Droid
{
    public class SqliteClient : Database 
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

            var path = Path.Combine(documentsPath, "uisrael.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}