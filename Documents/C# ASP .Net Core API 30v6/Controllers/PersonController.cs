using Microsoft.AspNetCore.Mvc;
using API30v6.Models;
using System.Collections.Generic;

namespace API30v6.Controllers
{
    public class PersonController : ControllerBase
    {
        private IPersonServices _personContext;
        public PersonController(IPersonServices personContext)
        {
            _personContext = personContext;
        }

        [HttpGet("people")]
        public ActionResult<List<Person>> GetPeople()
        {
            var item = _personContext.GetAll();
            return item;
        }

        [HttpGet("person/{id}")]
        public ActionResult<Person> GetPerson(int id)
        {
            var person = _personContext.Get(id);

            if (person == null)
                return NotFound();

            return person;
        }

        [HttpPost("person")]
        public IActionResult CreatePerson(Person person)
        {
            _personContext.AddPerson(person);
            return CreatedAtAction(nameof(CreatePerson), new { id = person.Id }, person);
        }

        // [HttpPost("people")]
        // public IActionResult CreatePeople(List<Person> person)
        // {
        //     PersonServices.AddPeople(person);
        //     return Ok("Successfully!");
        //     // var modelTemp = new List<TaskModel>();
        //     // for(int i=0; i< model.Count;i++)
        //     // {
        //     //     SampleWebApiServices.Add(model[i]);
        //     //     CreatedAtAction(nameof(CreateTasks), new { id = model[i].Id }, model);
        //     // }
        //     // return Ok();
        // }

        [HttpPut("person/{id}")]
        public IActionResult Update(int id, Person person)
        {
            if (id != person.Id)
            {
                return null;
            }
            var personed = _personContext.Get(id);
            if (personed is null)
            {
                return null;
            }
            _personContext.Update(person);
            return NoContent();
        }

        [HttpDelete("person/{id}")]
        public ActionResult<bool> Delete(int id)
        {
            var person = _personContext.Get(id);
            if (person is null)
            {
                return false;
            }
            _personContext.Delete(id);
            return true;
        }

        [HttpPost("person/filter")]
        public ActionResult<List<Person>> Filter(Person person)
        {
            var personTemp = _personContext.Filter(person);
            if (personTemp is null)
            {
                return null;
            }
            return personTemp;
        }
    }
}