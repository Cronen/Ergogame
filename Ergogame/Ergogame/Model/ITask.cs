using System;
using System.Collections.Generic;
using System.Text;

namespace Ergogame.Model
{
    interface ITask
    {
        int Id { get; set; }
        string Name { get; set; }
        DateTime Date { get; set; }
        string theDate { get; set; }
        string Description { get; set; }
        bool Open { get; set; }
        DateTime Completed { get; set; }
    }
}
