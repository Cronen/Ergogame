using System;
using System.Collections.Generic;
using System.Text;

namespace Ergogame.Model
{
    public class TopicTask: ITask
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string theDate
        {
            get { return Date.ToString("dd.MM.yyyy"); }
            set { }
        }
        public string Description { get; set; }
        public List<Material> Materials { get; set; }
        public bool Open { get; set; }
        public DateTime Completed { get; set; }

        public TopicTask(string name, DateTime date) : this(name, date, true)
        {
        }
        public TopicTask(string name, DateTime date, bool open)
        {
            Name = name;
            Date = date;
            Open = open;
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam urna nibh, mattis in sagittis nec, aliquam ac quam. Morbi tempus fringilla viverra. Ut fermentum, justo eget elementum efficitur, libero nulla luctus turpis, vel vehicula lorem felis nec purus. Fusce fermentum ante eu sapien interdum mattis. Pellentesque laoreet tortor sit amet tellus laoreet, vel tempor eros posuere. Integer aliquam vitae ligula tempus vehicula. Aliquam facilisis velit vitae magna semper tempus non in arcu. Vestibulum sed velit maximus justo imperdiet tempor nec molestie felis. Etiam tincidunt feugiat nisl, eu pulvinar nulla venenatis vel.";
            Materials = new List<Material>();
            Materials.Add(new Material("PowerPoint1"));
            Materials.Add(new Material("PowerPoint2"));
            Materials.Add(new Material("PowerPoint3"));

        }
        public string getDate()
        {
            return Date.ToString("yyyy.MM.dd");
        }
    }
}
