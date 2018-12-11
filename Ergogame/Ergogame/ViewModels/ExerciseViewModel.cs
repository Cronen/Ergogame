using System;
using System.Collections.Generic;
using System.Text;

namespace Ergogame.Model
{
    public class ExerciseViewModel
    {
        public string Name { get; set; }
        public string Solution { get; set; }
        public bool Completed { get; set; }
        public bool IsFocused { get; set; }
        public string Description { get; set; }

        public ExerciseViewModel(Exercise e)
        {
            Name = e.Name;
            Solution = e.Solution;
            Description = e.Description;
            Completed = false;
            IsFocused = false;
        }
    }
}
