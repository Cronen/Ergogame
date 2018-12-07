using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace Ergogame.Model
{
    [Table("User")]
    class Users
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Username { get; set; }
        public Users()
        {
        }
        public Users(string uname)
        {
            Username = uname;
        }
    }
}
