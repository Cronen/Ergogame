using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Ergogame.Model;
using Ergogame.Model.UserModels;
using SQLite;
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
            DropDatabase();
            CreateTables();
            if (db.Table<StudentTask>().Count() == 0)
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

            if (db.Table<TopicTask>().Count() == 0)
            {
                db.InsertWithChildren(new TopicTask("DB_Topic 1", DateTime.Now));
                db.InsertWithChildren(new TopicTask("DB_Topic 2", DateTime.Now));
                db.InsertWithChildren(new TopicTask("DB_TopicClosed 2", DateTime.Now, false));
                db.InsertWithChildren(new TopicTask("DB_TopicClosed 1", DateTime.Now, false));
                db.InsertWithChildren(new TopicTask("DB_TopicCompleted 1", DateTime.Now.AddDays(-3)) { Completed = DateTime.Now.AddDays(-3) });
                db.InsertWithChildren(new TopicTask("DB_TopicCompleted 1", DateTime.Now.AddDays(-6)) { Completed = DateTime.Now.AddDays(-3) });
            }
            if (db.Table<Users>().Count() == 0)
            {
                db.InsertWithChildren(new Users("admin"));
                db.InsertWithChildren(new Users("Student"));
            }
        }
        private void CreateTables()
        {
            db.CreateTable<StudentTask>();
            db.CreateTable<Exercise>();
            db.CreateTable<TopicTask>();
            db.CreateTable<Material>();
            db.CreateTable<Users>();
            db.CreateTable<Note>();
            db.CreateTable<Feedback>();
        }
        public List<ITask> GetTasks()
        {
            List<ITask> reList = new List<ITask>();
            var result = db.GetAllWithChildren<StudentTask>();
            var result2 = db.GetAllWithChildren<TopicTask>();
            foreach (var st in result)
            {
                reList.Add(st);
            }
            foreach (var t in result2)
            {
                reList.Add(t);
            }
            return reList;
        }
        public List<ITask> GetOpenTasks()
        {
            List<ITask> reList = new List<ITask>();
            foreach (ITask task in GetTasks())
            {
                if (task.Open && task.Completed == DateTime.MinValue)
                {
                    reList.Add(task);
                }
            }
            return reList;
        }
        public List<ITask> GetClosedTasks()
        {
            List<ITask> reList = new List<ITask>();
            foreach (ITask task in GetTasks())
            {
                if (!task.Open)
                {
                    reList.Add(task);
                }
            }
            return reList;
        }
        public List<ITask> GetCompletedTasks()
        {
            List<ITask> reList = new List<ITask>();
            foreach (ITask task in GetTasks())
            {
                if (task.Completed != DateTime.MinValue)
                {
                    reList.Add(task);
                }
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

        //Only use this to clear database in case of errors
        private void DropDatabase()
        {
            db.DropTable<StudentTask>();
            db.DropTable<Exercise>();
            db.DropTable<TopicTask>();
            db.DropTable<Material>();
            db.DropTable<Users>();
            db.DropTable<Note>();
            db.DropTable<Feedback>();
        }
    }
}
