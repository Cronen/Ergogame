using System;
using Ergogame.student;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ergogame.Model;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Ergogame
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            new DB_Handler().SetupDB_DummyData();
            //MainPage = new NavigationPage(new MainPage());
            MainPage = new NavigationPage(new TaskList());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
