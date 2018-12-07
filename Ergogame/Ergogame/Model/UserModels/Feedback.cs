using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Ergogame.Model.UserModels
{
    [Table("Feedback")]
    class Feedback
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [ForeignKey(typeof(Users))]
        public int UserID { get; set; }
        [ForeignKey(typeof(Note))]
        public int NoteID { get; set; }
        public string FeedbackText { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
