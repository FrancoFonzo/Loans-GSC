using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVC.DataAccess;
using MVC.Dto.Requests;
using MVC.Dto.Responses;
using MVC.Entities;

namespace MVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CategoriesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = unitOfWork.CategoriesRepository.GetAll();
            var categoriesResponses = mapper.Map<IEnumerable<CategoryResponse>>(categories);
            return Ok(categoriesResponses);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = unitOfWork.CategoriesRepository.GetById(id);

            if (category is null)
                return NotFound("Category not found");

            var categoryResponse = mapper.Map<CategoryResponse>(category);
            return Ok(categoryResponse);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CategoryRequest categoryRequest)
        {
            var catExists = unitOfWork.CategoriesRepository.Exists(c => c.Description == categoryRequest.Description);
            if (catExists)
            {
                return Conflict("Category already exists");
            }

            var category = mapper.Map<Category>(categoryRequest);

            unitOfWork.CategoriesRepository.Create(category);
            unitOfWork.SaveChanges();

            var categoryResponse = mapper.Map<CategoryResponse>(category);
            return Ok(categoryResponse);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CategoryRequest categoryRequest)
        {
            var category = unitOfWork.CategoriesRepository.GetById(id);

            if (category is null)
                return NotFound("Category not found");

            var catExists = unitOfWork.CategoriesRepository.Exists(c => c.Description == categoryRequest.Description);
            if (catExists)
            {
                return Conflict("Category already exists");
            }

            category.Description = categoryRequest.Description;

            unitOfWork.CategoriesRepository.Update(category);
            unitOfWork.SaveChanges();

            var categoryResponse = mapper.Map<CategoryResponse>(category);
            return Ok(categoryResponse);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = unitOfWork.CategoriesRepository.GetById(id);

            if (category is null)
                return NotFound("Category not found");

            unitOfWork.CategoriesRepository.Delete(category.Id);
            unitOfWork.SaveChanges();
            return NoContent();
        }
    }
}
