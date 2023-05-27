using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab1.Repositories;
using lab1.Models;
using lab1.Contacts;

namespace lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(StaticUserRepository.Get());
        }
        [HttpGet("{index}")]
        public ActionResult<int> Get([FromRoute] int index)
        {
            return Ok(StaticUserRepository.Get(index));
        }
        [HttpPost]
        public ActionResult Post([FromBody] AddNumberContract contract)
        {
            var user = new User()
            {
                Login = contract.Login,
                Password = contract.Password,
            };
            StaticUserRepository.Add(user);
            return Ok();
        }
        [HttpPut]
        public ActionResult Put([FromBody] EditNumberContract contract)
        {
            var user = new User()
            {
                Id = contract.Id,
                Login = contract.Login,
                Password = contract.Password,
            };
            if (StaticUserRepository.Update(user))
                return Ok();
            else return BadRequest($"User ID = {contract.Id} not found");
        }

        [HttpDelete("{index}")]
        public ActionResult Delete([FromRoute] int index)
        {
            if (StaticUserRepository.Delete(index))
                return Ok();
            else return BadRequest($"User ID = {index} not found");
        }
    }
}
