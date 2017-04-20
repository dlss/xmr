using Android.App;
//using Android.OS;
using Porable.Lib;
using SQLite;
using System;
using System.Diagnostics;
using System.IO;

namespace TaskAndroid
{
    [Application]
    public class TaskyApp: Application
    {
        public static TaskyApp Current { get; private set; }

        public Manager<TodoItem> TodoManager { get; set; }
        SQLiteConnection conn;

        public TaskyApp(IntPtr handle, global::Android.Runtime.JniHandleOwnership transfer)
            : base(handle, transfer)
        {
            Current = this;
        }

        public override void OnCreate()
        {
            base.OnCreate();

            var sqliteFilename = "TodoItemDB.db3";
            string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(libraryPath, sqliteFilename);
            conn = new SQLiteConnection(path);

            TodoManager = new Manager<TodoItem>(conn);
        }
    }
}