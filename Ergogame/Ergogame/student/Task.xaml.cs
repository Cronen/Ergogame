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
            int inttest = 1;
			InitializeComponent ();
		}
        private async void Task_Tabbed(object sender, ItemTappedEventArgs e)
        {
            StudentTask st = (StudentTask)e.Item;
            //Add nav to sent to specific task page
            await this.Navigation.PushModalAsync(new student.TaskDetailPageDetail());
        }
        private List<StudentTask> GenerateDummyData()
        {
            List<StudentTask> reList = new List<StudentTask>();
            reList.Add(new StudentTask("Task 1", DateTime.Now));
            reList.Add(new StudentTask("Task 2", DateTime.Now));
            reList.Add(new StudentTask("Dysfagi", DateTime.Now));
            return reList;
        }
    }
}