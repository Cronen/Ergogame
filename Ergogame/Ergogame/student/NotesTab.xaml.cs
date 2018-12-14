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
    public partial class NotesTab : TabbedPage
    {
        public NotesTab ()
        {
            InitializeComponent();
        }

        private async void TaskDescription(object sender, EventArgs e)
        {
            await this.Navigation.PushModalAsync(new student.NotesContainer.TaskDescription());
        }

        private async void MyNotes(object sender, EventArgs e)
        {
            await this.Navigation.PushModalAsync(new student.NotesContainer.MyNotes());
        }

        private async void Feedback(object sender, EventArgs e)
        {
            await this.Navigation.PushModalAsync(new student.NotesContainer.Feedback());
        }

        private async void Solution(object sender, EventArgs e)
        {
            await this.Navigation.PushModalAsync(new Solution());
        }
    }
}