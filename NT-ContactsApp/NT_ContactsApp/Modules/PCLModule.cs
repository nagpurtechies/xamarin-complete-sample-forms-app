using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using NT_ContactsApp.Data;

namespace NT_ContactsApp.Modules
{
    public class PCLModule : IModule
    {
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterType<ContactDatabase>();
        }
    }
}
