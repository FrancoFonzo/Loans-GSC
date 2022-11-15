namespace MVC.Dto
{
    public class CategoryResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<ThingResponse> Things { get; set; }
    }
}
