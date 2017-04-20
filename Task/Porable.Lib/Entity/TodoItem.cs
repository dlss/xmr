namespace Porable.Lib
{
    public class TodoItem : BusinessEntityBase
    {
        public TodoItem() { }

        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }
    }
}
