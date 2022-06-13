using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechnicalTest.Project.Infrastructure.Repositories;
using TechnicalTest.Project.Infrastructure;
using TechnicalTest.Project.Pagination;
using TechnicalTest.Project.Domain;

namespace TechnicalTest.Project.Controllers
{
    // Endpoint for practitioner
    [ApiController]
    [Route("[controller]")]
    public class PractitionerController : Controller
    {
        private RepositoryWrapper _repo;
        public PractitionerController(TestDbContext context)
        {
            _repo = new RepositoryWrapper(context);
        }

        // Get all items
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetListAsync()
        {

            // Query for all entities paginated and return
            var queryset = await _repo.PractitionerRepository.ListAsync(p => p.Id == p.Id);
            return Ok(queryset);
        }

        // Get all items in a paginated list
        // all/paginated?page=1&pagesize=10
        [HttpGet]
        [Route("all/paginated")]
        public async Task<IActionResult> GetListPaginatedAsync([FromQuery] PaginationModel @params)
        {

            // Query for all entities paginated and return
            var queryset = await _repo.PractitionerRepository.GetEntityListPaginatedAsync(p => p.Id == p.Id, @params);
            return Ok(queryset);
        }

        // Get all with ID
        [HttpGet]
        [Route("by_id/{id}")]
        public async Task<IActionResult> GetListByIDAsync(string id)
        {

            // Query for all entities with specific id
            var queryset = await _repo.PractitionerRepository.ListAsync(p => p.Id.Equals(id));
            return Ok(queryset);
        }

        // Get all with Age
        [HttpGet]
        [Route("by_age/{age}")]
        public async Task<IActionResult> GetListByIDAsync(int age)
        {

            // Query for all entities with specific id
            var queryset = await _repo.PractitionerRepository.ListAsync(p => p.Age.Equals(age));
            return Ok(queryset);
        }

        // Get all with first name
        [HttpGet]
        [Route("by_first_name/{first_name}")]
        public async Task<IActionResult> GetListByFirstNameAsync(string first_name)
        {

            // Query for all entities with specific first name
            var queryset = await _repo.PractitionerRepository.ListAsync(p => p.FirstName.Equals(first_name));
            return Ok(queryset);
        }

        // Get all with last name
        [HttpGet]
        [Route("by_last_name/{last_name}")]
        public async Task<IActionResult> GetListByLastNameAsync(string last_name)
        {

            // Query for all entities with specific first name
            var queryset = await _repo.PractitionerRepository.ListAsync(p => p.LastName.Equals(last_name));
            return Ok(queryset);
        }

        // Get all with practice number
        [HttpGet]
        [Route("by_practice_num/{practice_num}")]
        public async Task<IActionResult> GetListByPracticeNumAsync(string practice_num)
        {

            // Query for all entities with specific practice num
            var queryset = await _repo.PractitionerRepository.ListAsync(p => p.PracticeNumber.Equals(practice_num));
            return Ok(queryset);
        }

        // CRUD endpoints 
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Practitioner>> CreatePractitioner(Practitioner practitioner)
        {
            // Add the entity
            try
            {
                await _repo.PractitionerRepository.CreateAsync(practitioner);

                return Ok(practitioner);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<Practitioner>> UpdatePractitioner(Practitioner practitioner)
        {
            var originalPractitioner = await _repo.PractitionerRepository.UpdateAsync(practitioner);

            return Ok(originalPractitioner);
        }

        [HttpPost]
        [Route("delete")]
        public ActionResult<Practitioner> DeletePractitioner(Practitioner practitioner)
        {

            try
            {
                _repo.PractitionerRepository.Delete(practitioner);
                return Ok("Entity Deleted");
            }
            catch
            {
                return BadRequest("Entity does not exist");
            }
        }
    }
}

