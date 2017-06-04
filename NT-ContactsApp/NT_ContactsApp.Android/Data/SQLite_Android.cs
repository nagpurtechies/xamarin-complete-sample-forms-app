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
using SQLite.Net.Async;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;
using NT_ContactsApp.Data;

namespace NT_ContactsApp.Droid.Data
{
    public class SQLite_Android : ISQLite
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var sqliteFilename = "test.db";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string path = System.IO.Path.Combine(documentsPath, sqliteFilename);

            return new SQLiteAsyncConnection(
                () => new SQLiteConnectionWithLock(new SQLitePlatformAndroid(), new SQLiteConnectionString(path, true)));
        }
    }
}