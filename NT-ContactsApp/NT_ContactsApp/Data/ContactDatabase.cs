using NT_ContactsApp.Model;
using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT_ContactsApp.Data
{
    public class ContactDatabase
    {
        private SQLiteAsyncConnection _database;
        private static object locker = new object();
        public ContactDatabase(ISQLite sqLite)
        {
            _database = sqLite.GetConnection();
        }

        public async Task InitDatabase()
        {
            await _database.CreateTableAsync<XamarinPhoneContact>();
        }
        public async Task<int> AddItems<T>(List<T> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));
            var insertResult = await _database.InsertAsync(items);
            Debug.WriteLine("Inserted or replaced rows - {0}", insertResult);
            return insertResult;
        }
    }
}
