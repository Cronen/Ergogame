using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Ergogame.Model;
using SQLite;
using SQLiteNetExtensions;
using SQLiteNetExtensions.Extensions;
using Xamarin.Forms;

namespace Ergogame
{
    class DB_Handler
    {
        private SQLiteConnection db;
        public DB_Handler()
        {
            db = new SQLiteConnection(GetDBPath());
        }
        

        public void SetupDB_DummyData()
        {
            db.CreateTable<StudentTask>();
            db.CreateTable<Exercise>();
            if (db.Table<StudentTask> ().Count() == 0)
            {
                db.InsertWithChildren(new StudentTask("FromDB Exercise 1", DateTime.Now));
                db.InsertWithChildren(new StudentTask("FromDB Dysfagi", DateTime.Now));
                db.InsertWithChildren(new StudentTask("FromDB Closed 1", DateTime.Now.AddDays(3), false));
                db.InsertWithChildren(new StudentTask("FromDB Closed 2", DateTime.Now.AddDays(5), false));
                db.InsertWithChildren(new StudentTask("FromDB Closed 3", DateTime.Now.AddDays(10), false));
                db.InsertWithChildren(new StudentTask("FromDB Completed 1", DateTime.Now.AddDays(-3)) { Completed = DateTime.Now.AddDays(-3) });
                db.InsertWithChildren(new StudentTask("FromDB Completed 2", DateTime.Now.AddDays(-5)) { Completed = DateTime.Now.AddDays(-3) });
                db.InsertWithChildren(new StudentTask("FromDB Completed 3", DateTime.Now.AddDays(-10)) { Completed = DateTime.Now.AddDays(-3) });
            }
            //db.CreateTable<TopicTask>();
            //if (db.Table<TopicTask>().Count() == 0)
            //{
            //    db.Insert(new TopicTask("Topic 1", DateTime.Now));
            //    db.Insert(new TopicTask("Topic 2", DateTime.Now));
            //    db.Insert(new TopicTask("TopicClosed 2", DateTime.Now, false));
            //    db.Insert(new TopicTask("TopicClosed 1", DateTime.Now, false));
            //    db.Insert(new TopicTask("TopicCompleted 1", DateTime.Now.AddDays(-3)) { Completed = DateTime.Now.AddDays(-3) });
            //    db.Insert(new TopicTask("TopicCompleted 1", DateTime.Now.AddDays(-6)) { Completed = DateTime.Now.AddDays(-3) });
            //}

        }
        public List<ITask> GetTasks()
        {
            List<ITask> reList = new List<ITask>();
            var result = db.GetAllWithChildren<StudentTask>();
            foreach (var st in result)
            {
                reList.Add(st);
            }
            return reList;
        }
        public string GetDBPath()
        {
            string sqliteFilename = "ErgoDB.db3";
            string path = "";
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    break;
                case Device.iOS:
                    string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
                    path = Path.Combine(documentsPath, "..", "Library"); // Library folder
                    break;
                case Device.UWP:
                    throw new Exception("Get a new phone");
                default:
                    throw new Exception("Device not recognized");
            }
            return Path.Combine(path, sqliteFilename);
        }
    }
}
