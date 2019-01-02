using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Ergogame.Model
{
    [Table("Exercise")]
    public class Exercise
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [ForeignKey(typeof(ITask))]
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Solution { get; set; }
        public string Description { get; set; }

        public Exercise()
        {
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam urna nibh, mattis in sagittis nec, aliquam ac quam. Morbi tempus fringilla viverra. Ut fermentum, justo eget elementum efficitur, libero nulla luctus turpis, vel vehicula lorem felis nec purus. Fusce fermentum ante eu sapien interdum mattis. Pellentesque laoreet tortor sit amet tellus laoreet, vel tempor eros posuere. Integer aliquam vitae ligula tempus vehicula. Aliquam facilisis velit vitae magna semper tempus non in arcu. Vestibulum sed velit maximus justo imperdiet tempor nec molestie felis. Etiam tincidunt feugiat nisl, eu pulvinar nulla venenatis vel.";
        }
        public Exercise(string name)
        {
            Name = name;
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam urna nibh, mattis in sagittis nec, aliquam ac quam. Morbi tempus fringilla viverra. Ut fermentum, justo eget elementum efficitur, libero nulla luctus turpis, vel vehicula lorem felis nec purus. Fusce fermentum ante eu sapien interdum mattis. Pellentesque laoreet tortor sit amet tellus laoreet, vel tempor eros posuere. Integer aliquam vitae ligula tempus vehicula. Aliquam facilisis velit vitae magna semper tempus non in arcu. Vestibulum sed velit maximus justo imperdiet tempor nec molestie felis. Etiam tincidunt feugiat nisl, eu pulvinar nulla venenatis vel.";
            Solution = "Solution for " + name;

        }
    }
}
