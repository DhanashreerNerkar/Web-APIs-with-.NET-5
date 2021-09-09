using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_Application_1.DataAccess;
using ASP.NET_Core_Application_1.Models;
namespace ASP.NET_Core_Application_1.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly IDataAccessProvider _dataccessprovider;
        public PersonController(DataAccessProvider dataAccessProvider)
        { _dataccessprovider = dataAccessProvider; }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IEnumerable<PersonModel> Get()
        {
            return _dataccessprovider.GetPerson();
        }


        [HttpPost]
        public IActionResult Create([FromBody] PersonModel person)
        {
            if (ModelState.IsValid)
            {
                person.id = Convert.ToInt32(Guid.NewGuid());
                _dataccessprovider.AddPerson(person);
                return Ok();
            }
            return BadRequest();
        }


        [HttpGet("{id}")]
        public PersonModel Details(int id)
        { return _dataccessprovider.GetPersonSingleRecord(id); }

        [HttpPut]
        public IActionResult Edit([FromBody] PersonModel person)
        {
            if (ModelState.IsValid)
            {
                _dataccessprovider.UpdatePerson(person);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirm(int id)
        {
            var data = _dataccessprovider.GetPersonSingleRecord(id);
            if (data==null)
                { return NotFound(); }
            _dataccessprovider.DeletePerson(id);
            return Ok(); 
        }
    }
}
