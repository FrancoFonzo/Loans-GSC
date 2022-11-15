namespace MVC.Entities
{
    public class Category : EntityBase
    {
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public List<Thing> Things { get; set; }
    }
}