using DemoAPI.Entities.Models;
using DemoAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Controllers
{
    [Route("api/v1/APIDemo/{controller}")]
    public class PersonsController : Controller
    {
        //private DemoAPIContext _context = new DemoAPIContext();
        private UnitOfWork _unitOfWork = new UnitOfWork(new DemoAPIContext());

        [HttpGet]
        public IActionResult GetAllPersons()
        {
            var persons = _unitOfWork.Persons.Get();
            if (persons != null)
            {
                return Ok(persons);
            }
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Person person = _unitOfWork.Persons.GetById(id);
            if (person != null)
            {
                return Ok(person);
            }
            return BadRequest("No existe un registro con ese ID");
        }

        [HttpPost]
        public IActionResult InsertPerson([FromBody] Person person)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Persons.Insert(person);
                    _unitOfWork.Save();
                    return Created("DemoAPI/CreatePerson",person);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (DataException ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public IActionResult UpdatePerson([FromBody] Person person)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Persons.Update(person);
                    _unitOfWork.Save();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (DataException ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public IActionResult DeletePerson([FromHeader] int id)
        {
            if (id != 0)
            {
                _unitOfWork.Persons.Delete(id);
                _unitOfWork.Save();
                return Ok("Person Deleted");
            }
            else
            {
                return BadRequest("Id Invalido");
            }
        }
    }
}
