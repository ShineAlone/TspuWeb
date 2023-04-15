using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NumbersController : ControllerBase
    {
        [HttpGet("{size}")]
        public IActionResult Get([FromRoute] int size)
        {
            int[] myArray = new int[size];
            Random rand = new Random();

            for (int x = 0; x < myArray.Length; x++)
            {
                myArray[x] = rand.Next(20);
            }
            // int[] nums = new int[5];
            // Random rnd = new Random();
            // int num = rnd.Next();
            return Ok(myArray);
        }
    }
}