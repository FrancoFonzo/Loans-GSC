using MVC.Models;

namespace MVC.Dto
{
    public class CategoryResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        //No uso List<ThingViewModel> ya que solo necesito descripcion,
        // y evitao referencia circular
        public List<string> Things { get; set; }
    }
}
