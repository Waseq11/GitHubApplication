using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MWFinalProject2022
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTask : ContentPage
    {
        public AddTask()
        {
            InitializeComponent();
        }

        private void btnCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();  
        }

        private async void btnConfirm_Clicked(object sender, EventArgs e)
        {
            bool fieldsEmpty = txtId.Text == "" || txtTaskDescription.Text == "";
            if (fieldsEmpty)
            {
                await DisplayAlert("Alert", "Fields cannot be empty!", "OK");
            }
            else
            {
                if (DataSource.AddTask(new Task(txtId.Text, txtTaskDescription.Text, dpDate.Date)))
                {
                    await DisplayAlert("Alert", $"Task {txtId.Text} was Created!", "OK");
                    txtId.Text = "";
                    txtTaskDescription.Text = "";
                    dpDate.Date = DateTime.Now;
                }
                else
                {
                    await DisplayAlert("Alert", "Task ID already exists!", "OK");
                }
            }

            await Navigation.PopAsync();
        }
    }
}