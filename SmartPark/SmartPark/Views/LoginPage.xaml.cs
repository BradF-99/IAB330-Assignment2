using System;
using System.Collections.Generic;
using System.IO;
using SmartPark.Models;
using SmartPark.Tables;
using SQLite;
using Xamarin.Forms;

namespace SmartPark.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
        }


        void LoginAccepted(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UsersDatabase.db");
            var db = new SQLiteConnection(dbpath);

            var myquery = db.Table<RegisteredUsers>().Where(u => u.Username.Equals(EntryEmail.Text) && u.Password.Equals(EntryPassword.Text)).FirstOrDefault();

            if (myquery != null)
            {
                Application.Current.MainPage = new MainPage();
            }
            else
            {
                Device.InvokeOnMainThreadAsync(async () =>
                {
                    var result = await this.DisplayAlert("Failed!", "Wrong Username or Password", null, "Continue");
                    await Navigation.PushAsync(new LoginPage());
                });
            }
        }

        void SignUpClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new SignUpPage()));
        }

        void ForgotPasswordTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new PasswordRecoveryPage()));
        }
    }
}
