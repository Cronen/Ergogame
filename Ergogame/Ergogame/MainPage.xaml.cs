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
            InitializeComponent();
        }

        private async void Login(object sender, EventArgs eventArgs)
        {
            User user = new User(UsernameEntry.Text, PasswordEntry.Text);
            if (user.Email == "admin" && user.Password == "123")
            {
                await this.Navigation.PushModalAsync(new student.Task());
            }
            
        }
    }
}
