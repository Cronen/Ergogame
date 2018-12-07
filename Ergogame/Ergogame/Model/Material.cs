using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Ergogame.Model
{
    [Table("Material")]
    public class Material
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [ForeignKey(typeof(ITask))]
        public int TaskId { get; set; }
        public string MatName { get; set; }
        public string URL { get; set; }
        public Material(string name)
        {
            MatName = name;
            URL = @"https://en.wikipedia.org/wiki/Xamarin";
        }
        public Material()
        {
        }
    }
}
