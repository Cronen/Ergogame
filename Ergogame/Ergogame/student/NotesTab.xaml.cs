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
      

        public NotesTab ()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        private  void TaskDescription(object sender, EventArgs e)
        {
            tabcontentview.Children.Clear();
            tabcontentview.Children.Add(new TaskDescription_view());

        }

        private  void MyNotes(object sender, EventArgs e)
        {
            tabcontentview.Children.Clear();
            tabcontentview.Children.Add(new MyNotes_view());
        }

        private void Feedback(object sender, EventArgs e)
        {
            tabcontentview.Children.Clear();
            tabcontentview.Children.Add(new Feedback_view());
        }

        private  void Solution(object sender, EventArgs e)
        {
            tabcontentview.Children.Clear();
            tabcontentview.Children.Add(new Solution_view());
        }
    }
}