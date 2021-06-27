using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Entities;
using UdemyNLayerProject.Core.Services;

namespace UdemyNLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IService<Person> _personService;
        public PersonController(IService<Person> service)
        {
            _personService = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _personService.GetAllAsync();
            return Ok(persons);
        }
        //TODO:: Dto şeklinde dönülecek.00
        [HttpPost]
        public async Task<IActionResult> Save(Person person)
        {
            var newperson = await _personService.AddAsync(person);
            return Ok(newperson);
        }
    }
}
