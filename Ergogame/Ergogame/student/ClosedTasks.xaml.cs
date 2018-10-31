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
	public partial class ClosedTasks : ContentPage
	{
		public ClosedTasks ()
		{
            BindingContext = GenerateDummyData();
			InitializeComponent ();
		}
        private async void OnOpenTap(object sender, EventArgs e)
        {
            await this.Navigation.PushModalAsync(new Task(), false);
        }
        private List<StudentTask> GenerateDummyData()
        {
            List<StudentTask> reList = new List<StudentTask>();
            reList.Add(new StudentTask("Closed 1", DateTime.Now.AddDays(3)));
            reList.Add(new StudentTask("Closed 2", DateTime.Now.AddDays(5)));
            reList.Add(new StudentTask("Closed 2", DateTime.Now.AddDays(10)));
            return reList;
        }
    }
}