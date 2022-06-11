using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Project.Infrastructure.Repositories.Interfaces;

namespace TechnicalTest.Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok("Hello World");
        }
    }
}