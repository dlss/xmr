using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;

namespace Porable.Lib
{
    public class Database<T> where T : class, IBusinessEntity, new()
    {
        static object locker = new object();
        public SQLiteConnection database;
        public string path;

        public Database(SQLiteConnection conn)
        {
            database = conn;
            database.CreateTable<T>();
        }

        public IEnumerable<T> GetItems()
        {
            lock (locker)
            {
                return (from i in database.Table<T>() select i).ToList();
            }
        }

        public T GetItem(int id)
        {
            lock (locker)
            {
                return database.Table<T>().FirstOrDefault(x => x.ID == id);
            }
        }

        public int SaveItem(T item)
        {
            lock (locker)
            {
                if (item.ID != 0)
                {
                    database.Update(item);
                    return item.ID;
                }
                else
                {
                    return database.Insert(item);
                }
            }
        }

        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<T>(id);
            }
        }
    }
}
