using System;
using System.Collections.Generic;
using System.Text;

namespace Ergogame.Model
{
    class StudentTask
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string theDate {
            get { return Date.ToString("yyyy.MM.dd");}
            private set { }
        }
        public string Description { get; set; }
        public List<string> Materials { get; set; }
        public bool Open { get; set; }
        public StudentTask(string name, DateTime date): this(name, date, true)
        {
        }
        public StudentTask(string name, DateTime date, bool open)
        {
            Name = name;
            Date = date;
            Open = open;
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam urna nibh, mattis in sagittis nec, aliquam ac quam. Morbi tempus fringilla viverra. Ut fermentum, justo eget elementum efficitur, libero nulla luctus turpis, vel vehicula lorem felis nec purus. Fusce fermentum ante eu sapien interdum mattis. Pellentesque laoreet tortor sit amet tellus laoreet, vel tempor eros posuere. Integer aliquam vitae ligula tempus vehicula. Aliquam facilisis velit vitae magna semper tempus non in arcu. Vestibulum sed velit maximus justo imperdiet tempor nec molestie felis. Etiam tincidunt feugiat nisl, eu pulvinar nulla venenatis vel.";
            Materials.Add("PowerPoint1");
            Materials.Add("PowerPoint2");
            Materials.Add("PowerPoint3");
        }
        public string getDate()
        {
            return Date.ToString("yyyy.MM.dd");
        }
    }
}
