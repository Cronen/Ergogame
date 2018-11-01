using System;
using System.Collections.Generic;
using System.Text;

namespace Ergogame.Model
{
    interface ITask
    {
        string Name { get; set; }
        DateTime Date { get; set; }
        string theDate { get; set; }
        string Description { get; set; }
        bool Open { get; set; }
    }
}
