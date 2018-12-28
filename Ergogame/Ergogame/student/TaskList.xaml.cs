using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ergogame.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ergogame.student
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskList : ContentPage
    {
        private DB_Handler DB_Class;
        public TaskList()
        {
            DB_Class = new DB_Handler();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = DB_Class.GetOpenTasks();
            InitializeComponent();
            Resources["ImageSource"] = Resources["Arrow"];
        }
        private void OnOpenTap(object sender, EventArgs e)
        {
            BindingContext = DB_Class.GetOpenTasks();
            Resources["ImageSource"] = Resources["Arrow"];
            ResetMenuBG();
            Img_open.Source = "list.png";
            SL_open.BackgroundColor = (Color)this.Resources["lightbgColor"];
            LB_open.TextColor = Color.White;
        }
        private void OnClosedTap(object sender, EventArgs e)
        {
            BindingContext = DB_Class.GetClosedTasks();
            Resources["ImageSource"] = Resources["NoArrow"];
            ResetMenuBG();
            SL_Closed.BackgroundColor = (Color)this.Resources["lightbgColor"];
            LB_Closed.TextColor = Color.White;
        }
        private void OnCompletedTap(object sender, EventArgs e)
        {
            BindingContext = DB_Class.GetCompletedTasks();
            Resources["ImageSource"] = Resources["Arrow"];
            ResetMenuBG();
            SL_Completed.BackgroundColor = (Color)this.Resources["lightbgColor"];
            LB_Completed.TextColor = Color.White;
        }

        private async void TaskTabbed(object sender, ItemTappedEventArgs e)
        {
            ITask item = (ITask)e.Item;
            if (!item.Open)
            {
                return;
            }
            else if (item.Completed.Year != 1)
            {
                await this.Navigation.PushModalAsync(new NotesTab(item));
                return;
            }

            if (item.GetType().Equals(typeof(StudentTask)))
            {
                await this.Navigation.PushModalAsync(new TaskDetailPage());

            }
            else if ((item.GetType().Equals(typeof(TopicTask))))
            {
                await this.Navigation.PushModalAsync(new TopicDetails((TopicTask)item));
            }
            else
            {
                await DisplayAlert("Error", "Something went wrong, try again", "OK");
            }
        }
        private void ResetMenuBG()
        {
            SL_open.BackgroundColor = Color.White;
            SL_Closed.BackgroundColor = Color.White;
            SL_Completed.BackgroundColor = Color.White;

            LB_open.TextColor = (Color)this.Resources["DarkMain"];
            LB_Closed.TextColor = (Color)this.Resources["DarkMain"];
            LB_Completed.TextColor = (Color)this.Resources["DarkMain"];

            Img_open.Source = "listdark.png";
        }
    }
}