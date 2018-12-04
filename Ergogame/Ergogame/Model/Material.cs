using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Ergogame.Model
{
    [Table("Material")]
    public class Material
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string MatName { get; set; }
        public string URL { get; set; }
        public Material(string name)
        {
            MatName = name;
        }
    }
}
