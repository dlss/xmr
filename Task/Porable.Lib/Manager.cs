using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Porable.Lib
{
    public class Manager<T> where T : class,IBusinessEntity, new()
    {
        Repository<T> repository;

        public Manager(SQLiteConnection conn)
        {
            repository = new Repository<T>(conn);
        }

        public T GetTask(int id)
        {
            return repository.GetTask(id);
        }

        public IList<T> GetTasks()
        {
            return new List<T>(repository.GetTasks());
        }

        public int SaveTask(T item)
        {
            return repository.SaveTask(item);
        }

        public int DeleteTask(int id)
        {
            return repository.DeleteTask(id);
        }
    }
}
