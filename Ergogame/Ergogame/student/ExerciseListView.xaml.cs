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
        public ExerciseListView(TopicTask tt)
        {
            Task = tt;
            ExerciseList = new List<ExerciseViewModel>();
            foreach (Exercise e in Task.Exercises)
            {
                if (ExerciseList.Count == 0)
                {
                    ExerciseList.Add(new ExerciseViewModel(e) { Completed = true, IsFocused = true });
                }
                else
                {
                    ExerciseList.Add(new ExerciseViewModel(e));
                }
            }

            InitializeComponent();
            LV_Exercise.ItemsSource = ExerciseList;
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
                }
                else
                {
                    exercise.IsFocused = false;
                }
            }
            //2 lines to refresh listview
            LV_Exercise.ItemsSource = null;
            LV_Exercise.ItemsSource = ExerciseList;
            //3 lines tpo update content view
            Content_SL_Exercise.Children.Remove(CurrentView);
            CurrentView = new ExerciseView(exer);
            Content_SL_Exercise.Children.Add(CurrentView);
        }
    }
}