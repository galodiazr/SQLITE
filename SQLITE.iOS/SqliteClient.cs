using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using SQLite;
using Xamarin.Forms;
using SQLITE.iOS;
using System.IO;

[assembly:Dependency(typeof(SqliteClient))]

namespace SQLITE.iOS
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