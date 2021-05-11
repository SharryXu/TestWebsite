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
            if (DateTime.Now.Minute % 5 != 0){
                return Ok($"{System.Environment.MachineName}: Sounds great!{System.Environment.NewLine}");
            } else {
                return BadRequest($"{System.Environment.MachineName}: Sounds bad!{System.Environment.NewLine}");
            }
        }
    }
}
