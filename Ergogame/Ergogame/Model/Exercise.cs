﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Ergogame.Model
{
    [Table("Exercise")]
    public class Exercise
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [ForeignKey(typeof(StudentTask))]
        public int TaskId { get; set; }
        public string Name { get; set; }

        public Exercise()
        {
        }
        public Exercise(string name)
        {
            Name = name;
        }
    }
}