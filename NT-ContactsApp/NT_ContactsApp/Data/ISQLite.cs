using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT_ContactsApp.Data
{
    public interface ISQLite
    {
        SQLiteAsyncConnection GetConnection();
    }
}
