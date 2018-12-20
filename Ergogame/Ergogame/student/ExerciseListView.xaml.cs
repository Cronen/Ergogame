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
    public partial class ExerciseListView : ContentPage
    {
        TopicTask Task;
        List<ExerciseViewModel> ExerciseList;
        ExerciseView CurrentView;
        ExerciseViewModel SelectedExercise;
        private DB_Handler DB_Class;
        public ExerciseListView(TopicTask tt)
        {
            Task = tt;
            DB_Class = new DB_Handler();
            ExerciseList = new List<ExerciseViewModel>();
            foreach (Exercise e in Task.Exercises)
            {
                ExerciseList.Add(new ExerciseViewModel(e));
            }

            InitializeComponent();
            LV_Exercise.ItemsSource = ExerciseList;
            SelectedExercise = ExerciseList[0];
            Notes_input.Text = SelectedExercise.Notes;
            CurrentView = new ExerciseView(ExerciseList[0]);
            Content_SL_Exercise.Children.Add(CurrentView);

        }
        private void ExerciseTapped(object sender, ItemTappedEventArgs e)
        {
            ExerciseViewModel exer = (ExerciseViewModel)e.Item;
            foreach (var exercise in ExerciseList)
            {
                if (exercise == exer)
                {
                    //exercise.IsFocused = true;
                    exer.IsFocused = true;
                    SelectedExercise = exercise;
                    Notes_input.Text = exercise.Notes;
                }
                else
                {
                    exercise.IsFocused = false;
                }
            }
            RefreshListView();
            //3 lines tpo update content view
            Content_SL_Exercise.Children.Remove(CurrentView);
            CurrentView = new ExerciseView(exer);
            Content_SL_Exercise.Children.Add(CurrentView);
        }

        private async void Submit(object sender, EventArgs e)
        {
            bool AllCompleted = true;
            foreach (var eVM in ExerciseList)
            {
                if (!eVM.Completed)
                {
                    AllCompleted = false;
                    break;
                }
            }
            if (AllCompleted)
            {
                await Navigation.PushModalAsync(new Notes());
            }
            else
            {
                var answer = await DisplayAlert("Warning", "Not all exercises are completed. Continue anyway?", "Yes", "No");
                if (answer)
                {
                    await Navigation.PushModalAsync(new Notes());
                }
            }
        }

        private void Complete_Exercise(object sender, EventArgs e)
        {
            SelectedExercise.Notes = Notes_input.Text;
            SelectedExercise.Completed = true;
            DB_Class.InsertOrUpdateNote(SelectedExercise.Notes, SelectedExercise.Note_ID, SelectedExercise.ID);
            RefreshListView();
        }
        private void RefreshListView()
        {
            //2 lines to refresh listview
            LV_Exercise.ItemsSource = null;
            LV_Exercise.ItemsSource = ExerciseList;
        }
    }
}