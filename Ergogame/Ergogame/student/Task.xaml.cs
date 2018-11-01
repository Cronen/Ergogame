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
	public partial class Task : ContentPage
	{
		public Task ()
		{
            BindingContext = GenerateDummyData();
			InitializeComponent ();
		}
        private async void Task_Tabbed(object sender, ItemTappedEventArgs e)
        {
            ITask item = (ITask)e.Item;
            //Add nav to sent to specific task page
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
        private List<ITask> GenerateDummyData()
        {
            List<ITask> reList = new List<ITask>();
            reList.Add(new StudentTask("Exercise 1", DateTime.Now));
            reList.Add(new TopicTask("Topic 1", DateTime.Now));
            reList.Add(new StudentTask("Dysfagi", DateTime.Now));
            reList.Add(new TopicTask("Topic 2", DateTime.Now));
            return reList;
        }

        private async void OnClosedTap(object sender, EventArgs e)
        {
            await this.Navigation.PushModalAsync(new ClosedTasks(), false);
        }
    }
}