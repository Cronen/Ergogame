using System;
using System.Collections.Generic;
using System.Text;
using Ergogame.Model.UserModels;

namespace Ergogame.Model
{
    public class ExerciseViewModel
    {
        public int ID { get; set; }
        public int Note_ID { get; set; }
        public string Name { get; set; }
        public string Solution { get; set; }
        public bool Completed { get; set; }
        public bool IsFocused { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }

        public ExerciseViewModel(Exercise e)
        {
            Name = e.Name;
            Solution = e.Solution;
            Description = e.Description;
            ID = e.Id;
            SetNotes(e);
            if (string.IsNullOrEmpty(Notes))
                Completed = false;
            else
                Completed = true;
            IsFocused = false;
        }
        private void SetNotes(Exercise e)
        {
            var db = new DB_Handler();
            var result = db.GetNoteFromExcerise(e);
            if (result.Id != 0)
            {
                Notes = result.Notes;
                Note_ID = result.Id;
            }
        }
        public string GetFeedback()
        {
            var db = new DB_Handler();
            var Feedback = db.GetFeedbackFromNoteID(Note_ID);
            if (string.IsNullOrEmpty(Feedback.FeedbackText))
            {
                return "No feedback received yet";
            }
            return Feedback.FeedbackText;
        }
    }
}
