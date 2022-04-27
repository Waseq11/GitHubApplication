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
    public partial class EditTask : ContentPage
    {
        public EditTask()
        {
            InitializeComponent();
        }

        private async void btnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void btnConfirm_Clicked(object sender, EventArgs e)
        {
            if (await DataSource.EditTask(new Task(txtId.Text, txtTaskDescription.Text, dpDate.Date)))
            {
                await DisplayAlert("Alert", "Task Edited!", "OK");
            }
            else
            {
                await DisplayAlert("Alert", "Error on Trying to Edit Task!", "OK");
            }

            await Navigation.PopAsync();
        }
    }
}