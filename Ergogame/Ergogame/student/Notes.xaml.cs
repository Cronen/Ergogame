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
	public partial class Notes : ContentPage
	{
		public Notes ()
		{
			InitializeComponent ();
		}

	    private async void BackToTask(object sender, EventArgs e)
	    {
	        await Navigation.PopModalAsync();
        }
	}
}