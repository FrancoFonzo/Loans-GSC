using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.DataAccess;
using MVC.Dto;
using MVC.Entities;

namespace MVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PeopleController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public IActionResult GetAll()
        {
            var people = unitOfWork.PeopleRepository.GetAll();
            var peopleResponses = mapper.Map<IEnumerable<PersonResponse>>(people);
            return Ok(peopleResponses);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public IActionResult GetPerson(int id)
        {
            var person = unitOfWork.PeopleRepository.GetById(id);

            if (person is null)
                return NotFound("Person not found");

            var personResponse = mapper.Map<PersonResponse>(person);
            return Ok(personResponse);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create([FromBody] PersonRequest personRequest)
        {
            var personExists = unitOfWork.PeopleRepository.Exists(p => p.Name == personRequest.Name);
            if (personExists)
            {
                ModelState.AddModelError(nameof(personRequest.Name), "Person already exist");
                return BadRequest(ModelState);
            }

            var person = mapper.Map<Person>(personRequest);
            unitOfWork.PeopleRepository.Create(person);
            unitOfWork.SaveChanges();

            var personResponse = mapper.Map<PersonResponse>(person);
            return Ok(personResponse);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id, [FromBody] PersonRequest personRequest)
        {
            var person = unitOfWork.PeopleRepository.GetById(id);
            if (person is null)
                return NotFound("Person not found");
            
            if (person.Name != personRequest.Name)
            {
                var personExists = unitOfWork.PeopleRepository.Exists(p => p.Name == personRequest.Name);
                if (personExists)
                {
                    ModelState.AddModelError(nameof(personRequest.Name), "Person already exist");
                    return BadRequest(ModelState);
                }
            }
            
            person = mapper.Map(personRequest, person);
            unitOfWork.PeopleRepository.Update(person);
            unitOfWork.SaveChanges();

            var personResponse = mapper.Map<PersonResponse>(person);
            return Ok(personResponse);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var person = unitOfWork.PeopleRepository.GetById(id);
            if (person is null)
                return NotFound("Person not found");

            unitOfWork.PeopleRepository.Delete(person.Id);
            unitOfWork.SaveChanges();
            return Ok();
        }
    }
}
