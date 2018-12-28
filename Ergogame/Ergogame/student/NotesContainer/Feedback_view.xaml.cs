using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ergogame.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ergogame.student.NotesContainer
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Feedback_view : ContentView
	{
        List<ExerciseViewModel> exList;
        public Feedback_view(ITask task)
        {
            exList = new List<ExerciseViewModel>();
            InitializeComponent();
            if (task.GetType().Equals(typeof(TopicTask)))
            {
                TopicTask TheTask = (TopicTask)task;
                var tempList = new List<ExerciseViewModel>();
                foreach (var exercise in TheTask.Exercises)
                {
                    exList.Add(new ExerciseViewModel(exercise));
                }
                LB_NotesField.Text = exList[0].Notes;
                ED_Feedback.Text = exList[0].GetFeedback();
                exList[0].IsFocused = true;
                GenerateList();
            }
        }
        private void GenerateList()
        {
            foreach (var exVM in exList)
            {
                SL_list.Children.Add(GenerateButton(exVM));
            }
        }
        private Button GenerateButton(ExerciseViewModel ex)
        {
            Button reBtn = new Button();
            reBtn.Text = ex.Name;
            reBtn.CornerRadius = 5;
            reBtn.Margin = 0;
            reBtn.BorderColor = (Color)Application.Current.Resources["darkgreenColor"];
            reBtn.BorderWidth = 1;
            if (ex.IsFocused)
            {
                reBtn.BackgroundColor = (Color)Application.Current.Resources["darkgreenColor"];
                reBtn.TextColor = Color.White;
            }
            else
            {
                reBtn.BackgroundColor = Color.White;
                reBtn.TextColor = (Color)Application.Current.Resources["darkgreenColor"];
            }
            reBtn.Clicked += (sender, args) => ChangeContent(ex);
            return reBtn;
        }
        private void ChangeContent(ExerciseViewModel ex)
        {
            SL_list.Children.Clear();
            foreach (var exVM in exList)
            {
                if (exVM == ex)
                {
                    exVM.IsFocused = true;
                }
                else
                {
                    exVM.IsFocused = false;
                }
                SL_list.Children.Add(GenerateButton(exVM));
            }
            LB_NotesField.Text = ex.Notes;
            ED_Feedback.Text = ex.GetFeedback();
        }
        private void ED_EditFeedback(object sender, EventArgs e)
        {
            DB_Handler DB_Class = new DB_Handler();
            var feedback = ((Editor)sender).Text;
            var exerciseView = exList.First(ex => ex.IsFocused);
            if (exerciseView.FeedbackText != feedback)
            {
                exerciseView.FeedbackText = feedback;
                DB_Class.InsertOrUpdateFeedback(feedback, exerciseView.Note_ID, exerciseView.Feed_ID);
            }

        }
    }
}