using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MWFinalProject2022
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void btnSignUp_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUp());
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            if (await LoginAsync(txtUsername.Text, txtPassword.Text))
            {
                txtUsername.Text = "";
                txtPassword.Text = "";
                await Navigation.PushAsync(new UserPage());
            }
            else
            {
                await DisplayAlert("Alert", "Invalid username or password", "OK");
            }
        }

        private async Task<bool> LoginAsync(string username, string password)
        {
            foreach (User user in await App.Database.GetUsersAsync())
            {
                if (user.Username == username && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
