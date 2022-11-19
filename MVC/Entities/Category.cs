namespace MVC.Entities
{
    public class Category : EntityBase
    {
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public IList<Thing> Things { get; set; }
    }
}