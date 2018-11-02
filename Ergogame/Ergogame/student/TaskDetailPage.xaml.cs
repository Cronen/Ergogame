﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ergogame.student
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TaskDetailPage : ContentPage
	{
		public TaskDetailPage ()
		{
			InitializeComponent ();
		}
        private async void OnBack(object sender, EventArgs e)
        {
            await this.Navigation.PopModalAsync();
        }

        private async void ToTask(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new StudentTaskView());
        }
    }
}