﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ergogame.student;
using Xamarin.Forms;





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
                //Session["user"] = new User() { UserName = username, Password = "123" };
                //return RedirectToAction("Index", "Home");
                await this.Navigation.PushAsync(new student.Task());
            }

            //if (String.IsNullOrWhiteSpace(UsernameEntry.Text))
            //{
            //    DisplayAlert("admin", "Enter in Username", "Okay");
            //    return;
            //}

            //if (String.IsNullOrWhiteSpace(PasswordEntry.Text))
            //{
            //    DisplayAlert("123", "Enter in Password", "Okay");
            //    return;
            //}

            //throw new NotImplementedException();
        }
    }
}
