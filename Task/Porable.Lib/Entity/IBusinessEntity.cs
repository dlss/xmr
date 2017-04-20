using SQLite;

namespace Porable.Lib
{
    public interface IBusinessEntity
    {
        int ID { get; set; }
    }

    public abstract class BusinessEntityBase : IBusinessEntity
    {
        public BusinessEntityBase() { }
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}
