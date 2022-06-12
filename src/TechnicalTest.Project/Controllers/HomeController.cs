using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Project.Domain;
using TechnicalTest.Project.Infrastructure;
using TechnicalTest.Project.Infrastructure.Repositories;
using TechnicalTest.Project.Infrastructure.Repositories.Interfaces;
using TechnicalTest.Project.Pagination;

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