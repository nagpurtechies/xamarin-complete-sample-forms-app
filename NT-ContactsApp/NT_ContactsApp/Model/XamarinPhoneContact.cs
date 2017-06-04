using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT_ContactsApp.Model
{
    public class XamarinPhoneContact
    {
        public XamarinPhoneContact() { }
        [PrimaryKey]
        public string Id { get; set; }
        public string Tag { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Website { get; set; }
        public string Organization { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
