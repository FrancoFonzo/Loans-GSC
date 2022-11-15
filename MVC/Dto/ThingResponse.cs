namespace MVC.Dto
{
    public class ThingResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public CategoryResponse Category { get; set; }
    }
}
