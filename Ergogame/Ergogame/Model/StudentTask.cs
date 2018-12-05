using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Ergogame.Model
{
    [Table("StudentTask")]
    public class StudentTask : ITask
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string theDate
        {
            get { return Date.ToString("dd.MM.yyyy"); }
            set { }
        }
        public string Description { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Exercise> Exercises { get; set; }
        public bool Open { get; set; }
        public DateTime Completed { get; set; }

        public StudentTask(string name, DateTime date) : this(name, date, true)
        {
        }
        public StudentTask(string name, DateTime date, bool open)
        {
            Name = name;
            Date = date;
            Open = open;
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam urna nibh, mattis in sagittis nec, aliquam ac quam. Morbi tempus fringilla viverra. Ut fermentum, justo eget elementum efficitur, libero nulla luctus turpis, vel vehicula lorem felis nec purus. Fusce fermentum ante eu sapien interdum mattis. Pellentesque laoreet tortor sit amet tellus laoreet, vel tempor eros posuere. Integer aliquam vitae ligula tempus vehicula. Aliquam facilisis velit vitae magna semper tempus non in arcu. Vestibulum sed velit maximus justo imperdiet tempor nec molestie felis. Etiam tincidunt feugiat nisl, eu pulvinar nulla venenatis vel.";
            Exercises = new List<Exercise>();
            Exercises.Add(new Exercise("Exercise 1"));
            Exercises.Add(new Exercise("Exercise 2"));
            Exercises.Add(new Exercise("Exercise 3"));
        }
        public StudentTask()
        {
            Exercises = new List<Exercise>();
        }
        public string getDate()
        {
            return Date.ToString("yyyy.MM.dd");
        }
    }
}
