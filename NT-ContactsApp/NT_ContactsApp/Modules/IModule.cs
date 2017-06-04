using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT_ContactsApp.Modules
{
    public interface IModule
    {
        #region Methods

        /// <summary>
        /// Register the specified builder.
        /// </summary>
        /// <param name="builder">builder.</param>
        void Register(ContainerBuilder builder);

        #endregion
    }
}
