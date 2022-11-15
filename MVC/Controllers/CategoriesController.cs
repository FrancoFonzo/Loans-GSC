using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVC.DataAccess;
using MVC.Dto;
using MVC.Entities;
using MVC.Models;

namespace MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            var categories = unitOfWork.CategoryRepository.GetAll();
            var categoriesResponses = mapper.Map<IEnumerable<CategoryResponse>>(categories);
            return Ok(categoriesResponses);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            //TODO: check if map list<Things> of category
            var category = unitOfWork.CategoryRepository.GetById(id);
            
            if (category is null)
                return NotFound("Category not found");
            
            var categoryResponse = mapper.Map<CategoryResponse>(category);
            return Ok(categoryResponse);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CategoryRequest catRequest)
        {
            var catExists = unitOfWork.CategoryRepository.Exists(c => c.Description == catRequest.Description);
            if (catExists)
            {
                ModelState.AddModelError(nameof(catRequest.Description), "Category already exist");
                return BadRequest(ModelState);
            }

            var cat = mapper.Map<Category>(catRequest);

            unitOfWork.CategoryRepository.Create(cat);
            unitOfWork.SaveChanges();
            return Ok(cat);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CategoryRequest categoryRequest)
        {
            var cat = unitOfWork.CategoryRepository.GetById(id);

            if (cat is null)
                return NotFound("Category not found");

            var catExists = unitOfWork.CategoryRepository.Exists(c => c.Description == categoryRequest.Description);
            if (catExists)
            {
                ModelState.AddModelError(nameof(categoryRequest.Description), "Category already exist");
                return BadRequest(ModelState);
            }
            
            cat.Description = categoryRequest.Description;

            unitOfWork.CategoryRepository.Update(cat);
            unitOfWork.SaveChanges();
            return Ok(cat);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cat = unitOfWork.CategoryRepository.GetById(id);
            
            if (cat is null)
                return NotFound("Category not found");

            unitOfWork.CategoryRepository.Delete(cat.Id);
            unitOfWork.SaveChanges();
            return NoContent();
        }
    }
}
