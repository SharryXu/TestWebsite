using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebsite.Controllers
{
    [ApiController]
    public class HealthyController : ControllerBase
    {
        [HttpGet]
        public IActionResult Ping()
        {
            return Ok($"{System.Environment.NewLine}{System.Environment.MachineName}: Sounds great!{System.Environment.NewLine}{System.Environment.NewLine}");
        }
    }
}
