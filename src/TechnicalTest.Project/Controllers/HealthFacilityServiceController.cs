using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechnicalTest.Project.Domain;
using TechnicalTest.Project.Infrastructure.Repositories;
using TechnicalTest.Project.Infrastructure;
using TechnicalTest.Project.Pagination;

namespace TechnicalTest.Project.Controllers
{
    // Endpoint for health facilityservice
    [ApiController]
    [Route("[controller]")]
    public class HealthFacilityServiceController : Controller
    {
        private RepositoryWrapper _repo;
        public HealthFacilityServiceController(TestDbContext context)
        {
            _repo = new RepositoryWrapper(context);
        }

        // Get all items
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetListAsync()
        {

            // Query for all entities paginated and return
            var queryset = await _repo.HealthFacilityServiceRepository.ListAsync(hf => hf.ServiceId == hf.ServiceId);
            return Ok(queryset);
        }

        // Get all items in a paginated list
        // all/paginated?page=1&pagesize=10
        [HttpGet]
        [Route("all/paginated")]
        public async Task<IActionResult> GetListPaginatedAsync([FromQuery] PaginationModel @params)
        {

            // Query for all entities paginated and return
            var queryset = await _repo.HealthFacilityServiceRepository.GetEntityListPaginatedAsync(hf => hf.ServiceId == hf.ServiceId, @params);
            return Ok(queryset);
        }

        // Get all with service ID
        [HttpGet]
        [Route("by_service_id/{service_id}")]
        public async Task<IActionResult> GetListByIDAsync(string service_id)
        {

            // Query for all entities with specific id
            var queryset = await _repo.HealthFacilityServiceRepository.ListAsync(hf => hf.ServiceId.Equals(service_id));
            return Ok(queryset);
        }

        // Get all with health facility ID
        [HttpGet]
        [Route("by_health_facility_id/{health_facility_id}")]
        public async Task<IActionResult> GetListByHealthFacilityIdAsync(string health_facility_id)
        {

            // Query for all entities with specific Health facility id
            var queryset = await _repo.HealthFacilityServiceRepository.ListAsync(hf => hf.HealthFacilityId.Equals(health_facility_id));
            return Ok(queryset);
        }

        // CRUD endpoints 
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<HealthFacilityService>> CreateHealthFacilityService(HealthFacilityService facility)
        {
            // Add the entity
            try
            {
                await _repo.HealthFacilityServiceRepository.CreateAsync(facility);

                return Ok(facility);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<HealthFacilityService>> UpdateHealthFacilityService(HealthFacilityService facility)
        {
            var originalHealthFacility = await _repo.HealthFacilityServiceRepository.UpdateAsync(facility);

            return Ok(originalHealthFacility);
        }

        [HttpPost]
        [Route("delete")]
        public ActionResult<HealthFacilityService> DeleteHealthFacilityService(HealthFacilityService facility)
        {

            try
            {
                _repo.HealthFacilityServiceRepository.Delete(facility);
                return Ok("Entity Deleted");
            }
            catch
            {
                return BadRequest("Entity does not exist");
            }
        }
    }
}
