using NT_ContactsApp.Data;
using NT_ContactsApp.Model;
using NT_ContactsApp.Modules;
using Plugin.Contacts;
using Plugin.Contacts.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NT_ContactsApp
{
    public partial class MainPage : ContentPage
    {
        List<XamarinPhoneContact> mycontacts = new List<XamarinPhoneContact>() {
            new XamarinPhoneContact()
            {
                DisplayName = "John Appleseed",
                PhoneNumber = "+91123213"
            },
            new XamarinPhoneContact()
            {
                DisplayName = "Jane Appleseed",
                PhoneNumber = "+91123213"
            },
            new XamarinPhoneContact()
            {
                DisplayName = "John Bohn",
                PhoneNumber = "+91123213"
            },
            new XamarinPhoneContact()
            {
                DisplayName = "John Noseed",
                PhoneNumber = "+91123213"
            }
        };
        public MainPage()
        {
            InitializeComponent();
            ContactsListView.ItemsSource = mycontacts;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {

        }

        private async void LoadContacts_Clicked(object sender, EventArgs e)
        {
            if (await CrossContacts.Current.RequestPermission())
            {

                List<Contact> contacts = null;
                CrossContacts.Current.PreferContactAggregation = false;//recommended
                                                                       //run in background
                await Task.Run(async () =>
                {
                    if (CrossContacts.Current.Contacts == null)
                        return;

                    contacts = CrossContacts.Current.Contacts.ToList();

                    var xamC = from cont in contacts
                               where cont.Phones != null && cont.Phones.Count > 0
                               select new XamarinPhoneContact
                               {
                                   Id = cont.Id,
                                   DisplayName = cont.DisplayName,
                                   PhoneNumber = cont.Phones.FirstOrDefault().Number.ToString()
                               };
                    var db = IoC.Resolve<ContactDatabase>();
                    await db.AddItems(xamC.ToList());

                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        ContactsListView.ItemsSource = xamC.ToList();
                    });
                });
            }
        }
    }
}
