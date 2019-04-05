using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lr1WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lr1WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PersonController : ControllerBase
    {
        private static List<PersonModel> persons = new List<PersonModel>();

        [HttpGet]
        public ActionResult<IEnumerable<PersonModel>> Get()
        {
            return persons;
        }

        [HttpGet("{id}")]
        public ActionResult<PersonModel> Get(int id)
        {
            if (persons.Count <= id)
            {
                throw new IndexOutOfRangeException("Человека с таким номером анкеты нет!");
            }
            return persons[id];
        }


        [HttpPost]
        public void Post([FromBody] PersonModel personModel)
        {
            if (personModel != null)
            {
                persons.Add(personModel);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PersonModel personModel)
        {
            if (persons.Count <= id)
            {
                throw new IndexOutOfRangeException("Человека с таким номером анкеты нет!");
            }
            persons[id] = personModel;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (persons.Count <= id)
            {
                throw new IndexOutOfRangeException("Человека с таким номером анкеты нет!");
            }
            persons.RemoveAt(id);
        }
    }
}
