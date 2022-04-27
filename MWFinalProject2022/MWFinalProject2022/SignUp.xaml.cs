using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MWFinalProject2022
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUp : ContentPage
    {
        public SignUp()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            txtPassword.IsEnabled = false;
            txtRepeatPassword.IsEnabled = false;
            txtUsername.IsEnabled = false;
        }

        private void btnCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void btnCreate_Clicked(object sender, EventArgs e)
        {
            bool fieldsEmpty = txtUsername.Text == "" || txtPassword.Text == "" || txtRepeatPassword.Text == "";
            bool passwordMatch = txtPassword.Text == txtRepeatPassword.Text;
            if (fieldsEmpty)
            {
                await DisplayAlert("Alert", "Fields Cannot be empty!", "OK");
            }
            else
            {
                if (passwordMatch)
                {
                    if (await CreateUserAsync(txtUsername.Text, txtPassword.Text))
                    {
                        await DisplayAlert("Alert", $"User {txtUsername.Text} was Created!", "OK");
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("Alert", "Username already exists!", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Alert", "Passwords do not match!", "OK");
                }
            }

        }

        private async Task<bool> CreateUserAsync(string username, string password)
        {
            foreach (User user in await App.Database.GetUsersAsync())
            {
                if (user.Username == username)
                {
                    return false;
                }
            }

            await App.Database.SaveUserAsync(
                new User
                {
                    Username = username,
                    Password = password
                });
            return true;
        }

        private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            SearchBar sb = (SearchBar)sender;
            actIndicator.IsRunning = true;
            RequestApi(sb.Text);
        }


        private async void RequestApi(string user)
        {
            HttpClient client = new HttpClient(); 
            Uri uri = new Uri(String.Format($"https://api.github.com/users/{user}", string.Empty)); 
            HttpResponseMessage response = await client.GetAsync(uri);
            actIndicator.IsRunning = !response.IsSuccessStatusCode;

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
                txtUsername.Text = values["login"];
                avatar.Source = values["avatar_url"];
                txtPassword.IsEnabled = true;
                txtRepeatPassword.IsEnabled = true;
                txtUsername.IsEnabled = true;
            }
            
            else
            {
                avatar.Source = "profile.png";
                actIndicator.IsRunning = false;
            }



        }
    }
}