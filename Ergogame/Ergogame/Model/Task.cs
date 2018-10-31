using System;
using System.Collections.Generic;
using System.Text;

namespace Ergogame.Model
{
    class Task
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool Open { get; set; }
        public Task(string name, DateTime date): this(name, date, true)
        {
        }
        public Task(string name, DateTime date, bool open)
        {
            Name = name;
            Date = date;
            Open = open;
        }
    }
}
