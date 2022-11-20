using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVC.DataAccess;
using MVC.Dto;
using MVC.Entities;

namespace MVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PeopleController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var people = unitOfWork.PeopleRepository.GetAll();
            var peopleResponses = mapper.Map<IEnumerable<PersonResponse>>(people);
            return Ok(peopleResponses);
        }

        [HttpGet("{id}")]
        public IActionResult GetPerson(int id)
        {
            var person = unitOfWork.PeopleRepository.GetById(id);

            if (person is null)
                return NotFound("Person not found");

            var personResponse = mapper.Map<PersonResponse>(person);
            return Ok(personResponse);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
            return Ok(person);
        }

        // POST: PeopleController/Edit/5
        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [FromBody] PersonRequest personRequest)
        {
            var person = unitOfWork.PeopleRepository.GetById(id);
            if (person is null)
                return NotFound("Person not found");

            var personExists = unitOfWork.PeopleRepository.Exists(p => p.Name == personRequest.Name);
            if (personExists)
            {
                ModelState.AddModelError(nameof(personRequest.Name), "Person already exist");
                return BadRequest(ModelState);
            }

            person = mapper.Map(personRequest, person);
            unitOfWork.PeopleRepository.Update(person);
            unitOfWork.SaveChanges();
            return Ok(person);
        }

        // POST: PeopleController/Delete/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var person = unitOfWork.PeopleRepository.GetById(id);
            if (person is null)
                return NotFound("Person not found");

            unitOfWork.PeopleRepository.Delete(person);
            unitOfWork.SaveChanges();
            return Ok();
        }
    }
}
