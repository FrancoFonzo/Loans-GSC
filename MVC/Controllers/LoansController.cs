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
    public class LoansController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public LoansController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var loans = unitOfWork.LoansRepository.GetAllWithPersonThing();
            var loansResponses = mapper.Map<IEnumerable<LoanResponse>>(loans);
            return Ok(loansResponses);
        }

        [HttpGet("{id}")]
        public IActionResult GetLoan(int id)
        {
            var loan = unitOfWork.LoansRepository.GetByIdWithPersonThing(id);

            if (loan is null)
                return NotFound("Loan not found");

            var loanResponse = mapper.Map<LoanResponse>(loan);
            return Ok(loanResponse);
        }

        [HttpPost]
        public IActionResult Create([FromBody] LoanRequest loanRequest)
        {
            var loan = mapper.Map<Loan>(loanRequest);

            var thing = unitOfWork.ThingsRepository.GetById(loan.ThingId);
            if (thing is null)
                return NotFound("Thing not found");

            var person = unitOfWork.PeopleRepository.GetById(loan.PersonId);
            if (person is null)
                return NotFound("Person not found");

            unitOfWork.LoansRepository.Create(loan);
            unitOfWork.SaveChanges();
            var loanResponse = mapper.Map<LoanResponse>(loan);
            return Ok(loanResponse);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var loan = unitOfWork.LoansRepository.GetByIdWithPersonThing(id);

            if (loan is null)
                return NotFound("Loan not found");

            unitOfWork.LoansRepository.Delete(loan.Id);
            unitOfWork.SaveChanges();
            return Ok();
        }
    }
}
