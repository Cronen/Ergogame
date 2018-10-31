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
        public bool Open { get; set; }
        public StudentTask(string name, DateTime date): this(name, date, true)
        {
        }
        public StudentTask(string name, DateTime date, bool open)
        {
            Name = name;
            Date = date;
            Open = open;
        }
        public string getDate()
        {
            return Date.ToString("yyyy.MM.dd");
        }
    }
}
