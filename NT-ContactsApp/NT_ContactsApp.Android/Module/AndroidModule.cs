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
using Autofac;
using NT_ContactsApp.Data;
using NT_ContactsApp.Droid.Data;

namespace NT_ContactsApp.Droid.Module
{
    public class AndroidModule : NT_ContactsApp.Modules.IModule
    {
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterType<SQLite_Android>().As<ISQLite>();
        }
    }
}