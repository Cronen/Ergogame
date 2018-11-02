using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ergogame.student
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentTaskView : ContentPage
    {
        public StudentTaskView()
        {
            InitializeComponent();
        }

        private async void ToNotes(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Notes());
        }
    }
}