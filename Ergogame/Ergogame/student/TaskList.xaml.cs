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
        public TaskList()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = GenerateDummyData();
            InitializeComponent();
            Resources["ImageSource"] = Resources["Arrow"];
        }
        private void OnOpenTap(object sender, EventArgs e)
        {
            BindingContext = GenerateDummyData();
            Resources["ImageSource"] = Resources["Arrow"];
            ResetMenuBG();
            Img_open.Source = "list.png";
            SL_open.BackgroundColor = (Color)this.Resources["lightbgColor"];
            LB_open.TextColor = Color.White;
        }
        private void OnClosedTap(object sender, EventArgs e)
        {
            BindingContext = GenerateDummyDataClosed();
            Resources["ImageSource"] = Resources["NoArrow"];
            ResetMenuBG();
            SL_Closed.BackgroundColor = (Color)this.Resources["lightbgColor"];
            LB_Closed.TextColor = Color.White;
        }
        private void OnCompletedTap(object sender, EventArgs e)
        {
            BindingContext = GenerateDummyDataCompleted();
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
                await this.Navigation.PushModalAsync(new Notes());
                return;
            }

            if (item.GetType().Equals(typeof(StudentTask)))
            {
                await this.Navigation.PushModalAsync(new student.TaskDetailPage());

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
        private List<ITask> GenerateDummyData()
        {
            List<ITask> reList = new List<ITask>();
            reList.Add(new StudentTask("Exercise 1", DateTime.Now));
            reList.Add(new TopicTask("Topic 1", DateTime.Now));
            reList.Add(new StudentTask("Dysfagi", DateTime.Now));
            reList.Add(new TopicTask("Topic 2", DateTime.Now));
            return reList;
        }
        private List<StudentTask> GenerateDummyDataClosed()
        {
            List<StudentTask> reList = new List<StudentTask>();
            reList.Add(new StudentTask("Closed 1", DateTime.Now.AddDays(3), false));
            reList.Add(new StudentTask("Closed 2", DateTime.Now.AddDays(5), false));
            reList.Add(new StudentTask("Closed 3", DateTime.Now.AddDays(10), false));
            return reList;
        }
        private List<StudentTask> GenerateDummyDataCompleted()
        {
            List<StudentTask> reList = new List<StudentTask>();
            reList.Add(new StudentTask("Completed 1", DateTime.Now.AddDays(-3)) { Completed = DateTime.Now.AddDays(-3) });
            reList.Add(new StudentTask("Completed 2", DateTime.Now.AddDays(-5)) { Completed = DateTime.Now.AddDays(-3) });
            reList.Add(new StudentTask("Completed 3", DateTime.Now.AddDays(-10)) { Completed = DateTime.Now.AddDays(-3) });
            return reList;
        }
    }
}