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


        public NotesTab()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            tabcontentview.Children.Add(new MyNotes_view());
        }

        private void TaskDescription(object sender, EventArgs e)
        {
            ClearBG();
            SL_desc.BackgroundColor = (Color)Application.Current.Resources["darkgreenColor"];
            LB_desc.TextColor = Color.White;
            tabcontentview.Children.Clear();
            tabcontentview.Children.Add(new TaskDescription_view());

        }

        private void MyNotes(object sender, EventArgs e)
        {
            ClearBG();
            SL_notes.BackgroundColor = (Color)Application.Current.Resources["darkgreenColor"];
            LB_notes.TextColor = Color.White;
            tabcontentview.Children.Clear();
            tabcontentview.Children.Add(new MyNotes_view());
        }

        private void Feedback(object sender, EventArgs e)
        {
            ClearBG();
            SL_feed.BackgroundColor = (Color)Application.Current.Resources["darkgreenColor"];
            LB_feed.TextColor = Color.White;
            tabcontentview.Children.Clear();
            tabcontentview.Children.Add(new Feedback_view());
        }

        private void Solution(object sender, EventArgs e)
        {
            ClearBG();
            SL_solu.BackgroundColor = (Color)Application.Current.Resources["darkgreenColor"];
            LB_solu.TextColor = Color.White;
            tabcontentview.Children.Clear();
            tabcontentview.Children.Add(new Solution_view());
        }
        private void ClearBG()
        {
            SL_desc.BackgroundColor = (Color)Application.Current.Resources["bgColor"];
            SL_feed.BackgroundColor = (Color)Application.Current.Resources["bgColor"];
            SL_notes.BackgroundColor = (Color)Application.Current.Resources["bgColor"];
            SL_solu.BackgroundColor = (Color)Application.Current.Resources["bgColor"];

            LB_desc.TextColor = (Color)Application.Current.Resources["darkgreenColor"];
            LB_feed.TextColor = (Color)Application.Current.Resources["darkgreenColor"];
            LB_notes.TextColor = (Color)Application.Current.Resources["darkgreenColor"];
            LB_solu.TextColor = (Color)Application.Current.Resources["darkgreenColor"];

        }
    }
}