using Domain;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UnitOfwork.Controllers.V1
{
    [ApiController]
    [Route("controller")]
    public class PersonController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public PersonController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Person> GetAllPersons()
        {
            return unitOfWork.Person.GetAll();
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<Person> GetAdultPerson()
        {
            return unitOfWork.Person.GetAdultPerson();
        }
    }
}