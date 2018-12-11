using Ergogame.Model;
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
	public partial class ExerciseView : ContentView
	{
        ExerciseViewModel Exercise;

        public ExerciseView (ExerciseViewModel EVM)
		{
            Exercise = EVM;
            InitializeComponent ();
            Exercise_Headline.Text = Exercise.Name;
            Exercise_Description.Text = Exercise.Description;

        }
	}
}