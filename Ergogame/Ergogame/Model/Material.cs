using System;
using System.Collections.Generic;
using System.Text;

namespace Ergogame.Model
{
    public class Material
    {
        public string MatName { get; set; }
        public Uri URL { get; set; }
        public Material(string name)
        {
            MatName = name;
        }
    }
}
