using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebsite.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HealthyController : ControllerBase
    {
        [HttpGet]
        public IActionResult Ping()
        {
            if (DateTime.Now.Minute % 2 == 0){
                return Ok("Sounds great!");
            } else {
                return BadRequest("Sounds bad!");
            }
        }
    }
}
