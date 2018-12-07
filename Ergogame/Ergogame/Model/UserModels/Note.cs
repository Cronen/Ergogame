using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Ergogame.Model.UserModels
{
    [Table("Notes")]
    class Note
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [ForeignKey(typeof(Users))]
        public int UserID { get; set; }
        [ForeignKey(typeof(Exercise))]
        public int ExerciseID { get; set; }
        public string notes { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
