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
	public partial class TaskDetailPage : ContentPage
	{
        ITask Task;
		public TaskDetailPage (StudentTask task)
		{
            Task = task;
			InitializeComponent ();
		}
        private async void OnBack(object sender, EventArgs e)
        {
            await this.Navigation.PopModalAsync();
        }

        private async void ToTask(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new StudentTaskView(Task));
        }
    }
}