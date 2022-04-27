using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MWFinalProject2022
{
    public partial class App : Application
    {
        static Database database;

        internal static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "users.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            DataSource.AddTask(new Task("MU6-123", "Create Xamarin Project", new DateTime(2022, 7, 23)));
            DataSource.AddTask(new Task("MU6-456", "Debug CSharp Code",  new DateTime(2022, 5, 22)));
            DataSource.AddTask(new Task("MU6-789", "Do Unit Test on applicationXamarin", new DateTime(2022, 6, 12)));
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
