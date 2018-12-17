using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Ergogame.student.NotesContainer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ergogame.student
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesTab : ContentPage
    {
        NotesTab ContentView;

        public NotesTab ()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        private async void TaskDescription(object sender, EventArgs e)
        {
          tabcontentview.Children.Add(new TaskDescription_view());

        }

        private async void MyNotes(object sender, EventArgs e)
        {
            tabcontentview.Children.Add(new MyNotes_view());
        }

        private async void Feedback(object sender, EventArgs e)
        {
            tabcontentview.Children.Add(new Feedback_view());
        }

        private async void Solution(object sender, EventArgs e)
        {
            tabcontentview.Children.Add(new Solution_view());
        }
    }
}