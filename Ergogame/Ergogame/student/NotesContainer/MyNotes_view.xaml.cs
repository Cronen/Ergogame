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
    public partial class MyNotes_view : ContentView
    {
        List<ExerciseViewModel> exList;
        public MyNotes_view(ITask task)
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
                ED_NotesField.Text = exList[0].Notes;
                LB_Feedback.Text = exList[0].GetFeedback();
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
            reBtn.CornerRadius = 0;
            reBtn.Margin = 0;
            reBtn.BorderColor = (Color)Application.Current.Resources["lightgreenColor"];
            reBtn.BorderWidth = 0.5;
            if (ex.IsFocused)
            {
                reBtn.BackgroundColor = (Color)Application.Current.Resources["lightgreenColor"];
                reBtn.TextColor = Color.White;
            }
            else
            {
                reBtn.BackgroundColor = Color.White;
                reBtn.TextColor = (Color)Application.Current.Resources["lightgreenColor"];
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
            ED_NotesField.Text = ex.Notes;
            LB_Feedback.Text = ex.GetFeedback();
        }
        private void ED_EditNote(object sender, EventArgs e)
        {
            DB_Handler DB_Class = new DB_Handler();
            var note = ((Editor) sender).Text;
            var exerciseView = exList.First(ex => ex.IsFocused);
            if (exerciseView.Notes != note)
            {
                exerciseView.Notes = note;
                DB_Class.InsertOrUpdateNote(exerciseView.Notes, exerciseView.Note_ID, exerciseView.ID);
            }            
        }
    }
}