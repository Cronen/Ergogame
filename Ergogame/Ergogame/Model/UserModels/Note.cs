using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Ergogame.Model.UserModels
{
    [Table("Notes")]
    public class Note
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [ForeignKey(typeof(Users))]
        public int UserID { get; set; }
        [ForeignKey(typeof(Exercise))]
        public int ExerciseID { get; set; }
        public string Notes { get; set; }
        public DateTime CreateDate { get; set; }
        public Note()
        {
        }
        public Note(string notes, int user, int exercise)
        {
            CreateDate = DateTime.Now;
            UserID = user;
            ExerciseID = exercise;
            Notes = notes;
        }
    }
}
