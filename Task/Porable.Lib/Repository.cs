using SQLite;
using System;
using System.Collections.Generic;
using System.IO;


namespace Porable.Lib
{
    public class Repository<T> where T : class, IBusinessEntity, new()
    {
        Database<T> db = null;

        public Repository(SQLiteConnection conn)
        {
            db = new Database<T>(conn);
        }

        public T GetTask(int id)
        {
            return db.GetItem(id);
        }

        public IEnumerable<T> GetTasks()
        {
            return db.GetItems();
        }

        public int SaveTask(T item)
        {
            return db.SaveItem(item);
        }

        public int DeleteTask(int id)
        {
            return db.DeleteItem(id);
        }
    }
}
