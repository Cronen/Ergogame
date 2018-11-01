using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ergogame.student;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Ergogame
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        private async void Login(object sender, EventArgs eventArgs)
        {
            User user = new User(UsernameEntry.Text, PasswordEntry.Text);

             if (user.Email == "admin" && user.Password == "123")
                {
                    Navigation.InsertPageBefore(new TaskList(), this);
                    await Navigation.PopAsync();

                }

                else
                {
                    if (user.Email == "teacher" && user.Password == "123")
                    {
                        await Navigation.PushModalAsync(new teacher.SelectSemester());
                    }

                    else
                    {
                        await DisplayAlert("Wrong Login", "Try again", "OK");
                        UsernameEntry.Text = "";
                        PasswordEntry.Text = "";
                    }
                }

               

            //if (user.Email == "admin" && user.Password == "123")
            //{
            //    await this.Navigation.PushModalAsync(new student.Task());
            //}
            //else
            //{
            //    await DisplayAlert("Wrong Login", "Try again", "OK");
            //    UsernameEntry.Text = "";
            //    PasswordEntry.Text = "";
            //}

        }
    }
}
