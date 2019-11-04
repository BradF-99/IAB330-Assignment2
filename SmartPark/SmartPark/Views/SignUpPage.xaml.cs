using System;
using System.Collections.Generic;
using System.IO;
using SmartPark.Tables;
using SQLite;
using Xamarin.Forms;

namespace SmartPark.Views
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
        }
        void OnSignupClicked(object sender, EventArgs args)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UsersDatabase.db");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<RegisteredUsers>();

            if(EntryPassword.Text == EntryPasswordConfirm.Text && EntryEmail.Text != null && EntryPassword.Text != null && EntryPasswordConfirm.Text != null)
            {
                var item = new RegisteredUsers()
                {
                    Username = EntryEmail.Text,
                    Password = EntryPassword.Text
                };

                db.Insert(item);
                Device.InvokeOnMainThreadAsync(async () =>
                {
                    var result = await this.DisplayAlert("Success!", "User Registered", null, "Continue");
                });
            }
            else if (EntryEmail.Text == null)
            { 
                Device.InvokeOnMainThreadAsync(async () =>
                {
                    var result = await this.DisplayAlert("Failed!", "Email Field is Empty", null, "Continue");
                });
            }
            else if (EntryPassword.Text == null || EntryPasswordConfirm.Text == null)
            {
                Device.InvokeOnMainThreadAsync(async () =>
                {
                    var result = await this.DisplayAlert("Failed!", "Password Fields Empty", null, "Continue");
                });
            }
            else
            {
                Device.InvokeOnMainThreadAsync(async () =>
                {
                    var result = await this.DisplayAlert("Failed!", "Passwords Do Not Match", null, "Continue");
                });
            }

        }
    }
}
