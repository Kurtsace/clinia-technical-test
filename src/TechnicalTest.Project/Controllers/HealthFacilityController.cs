using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechnicalTest.Project.Domain;
using TechnicalTest.Project.Infrastructure;
using TechnicalTest.Project.Infrastructure.Repositories;
using TechnicalTest.Project.Pagination;

namespace TechnicalTest.Project.Controllers
{
    // Endpoint for health facility
    [ApiController]
    [Route("[controller]")]
    public class HealthFacilityController : Controller
    {
        private RepositoryWrapper _repo;
        public HealthFacilityController(TestDbContext context)
        {
            _repo = new RepositoryWrapper(context);
        }

        // Get all items
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetListAsync()
        {

            // Query for all entities paginated and return
            var queryset = await _repo.HealthFacilityRepository.ListAsync(hf => hf.Id == hf.Id);
            return Ok(queryset);
        }

        // Get all items in a paginated list
        // all/paginated?page=1&pagesize=10
        [HttpGet]
        [Route("all/paginated")]
        public async Task<IActionResult> GetListPaginatedAsync([FromQuery] PaginationModel @params)
        {

            // Query for all entities paginated and return
            var queryset = await _repo.HealthFacilityRepository.GetEntityListPaginatedAsync(hf => hf.Id == hf.Id, @params);
            return Ok(queryset);
        }

        // Get all with ID
        [HttpGet]
        [Route("by_id/{id}")]
        public async Task<IActionResult> GetListByIDAsync(string id)
        {

            // Query for all entities with specific id
            var queryset = await _repo.HealthFacilityRepository.ListAsync(hf => hf.Id.Equals(id));
            return Ok(queryset);
        }

        // Get all with name
        [HttpGet]
        [Route("by_name/{name}")]
        public async Task<IActionResult> GetListByNameAsync(string name)
        {

            // Query for all entities with specific name
            var queryset = await _repo.HealthFacilityRepository.ListAsync(hf => hf.Name.Equals(name));
            return Ok(queryset);
        }

        // Get all in city
        [HttpGet]
        [Route("by_city/{city}")]
        public async Task<IActionResult> GetListByCityAsync(string city)
        {

            // Query for all entities with specific name
            var queryset = await _repo.HealthFacilityRepository.ListAsync(hf => hf.City.Equals(city));
            return Ok(queryset);
        }

        // Get that are open
        [HttpGet]
        [Route("is_open/{isOpen}")]
        public async Task<IActionResult> GetListByCityAsync(bool isOpen)
        {

            // Query for all entities with specific name
            var queryset = await _repo.HealthFacilityRepository.ListAsync(hf => hf.IsOpen.Equals(isOpen));
            return Ok(queryset);
        }

        // CRUD endpoints 
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<HealthFacility>> CreateHealthFacility(HealthFacility facility)
        {
            // Add the entity
            try
            {
                await _repo.HealthFacilityRepository.CreateAsync(facility);

                return Ok(facility);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<HealthFacility>> UpdateHealthFacility(HealthFacility facility)
        {
            var originalHealthFacility = await _repo.HealthFacilityRepository.UpdateAsync(facility);

            return Ok(originalHealthFacility);
        }

        [HttpPost]
        [Route("delete")]
        public ActionResult<HealthFacility> DeleteHealthFacility(HealthFacility facility)
        {

            try
            {
                _repo.HealthFacilityRepository.Delete(facility);
                return Ok("Entity Deleted");
            }
            catch
            {
                return BadRequest("Entity does not exist");
            }
        }
    }
}
