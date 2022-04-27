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
    public partial class UserPage : ContentPage
    {
        int index;

        public UserPage()
        {
            InitializeComponent();
            listTasks.ItemsSource = DataSource.GetTasks();
        }

        protected override void OnAppearing()
        {
            btnEdit.IsVisible = false;
            btnDelete.IsVisible = false;
        }

        private void listTasks_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            index = e.SelectedItemIndex;
            btnEdit.IsVisible = true;
            btnDelete.IsVisible = true;
        }

        private void btnAdd_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddTask());
        }

        private void btnEdit_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditTask());
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Alert", "Are you sure?", "Yes", "No");
            if (answer)
            {
                await DataSource.DeleteTask(DataSource.myTasks[index].TaskId);
            }
            listTasks.ItemsSource = DataSource.myTasks;
        }
    }
}