using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechnicalTest.Project.Infrastructure.Repositories;
using TechnicalTest.Project.Infrastructure;
using TechnicalTest.Project.Pagination;
using TechnicalTest.Project.Domain;

namespace TechnicalTest.Project.Controllers
{
    // Endpoint for practitioner service
    [ApiController]
    [Route("[controller]")]
    public class PractitionerServiceController : Controller
    {
        private RepositoryWrapper _repo;
        public PractitionerServiceController(TestDbContext context)
        {
            _repo = new RepositoryWrapper(context);
        }

        // Get all items
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetListAsync()
        {

            // Query for all entities paginated and return
            var queryset = await _repo.PractitionerServiceRepository.ListAsync(p => p.ServiceId == p.ServiceId);
            return Ok(queryset);
        }

        // Get all items in a paginated list
        // all/paginated?page=1&pagesize=10
        [HttpGet]
        [Route("all/paginated")]
        public async Task<IActionResult> GetListPaginatedAsync([FromQuery] PaginationModel @params)
        {

            // Query for all entities paginated and return
            var queryset = await _repo.PractitionerServiceRepository.GetEntityListPaginatedAsync(p => p.ServiceId == p.ServiceId, @params);
            return Ok(queryset);
        }

        // Get all with service ID
        [HttpGet]
        [Route("by_service_id/{service_id}")]
        public async Task<IActionResult> GetListByServiceIDAsync(string service_id)
        {

            // Query for all entities with specific id
            var queryset = await _repo.PractitionerServiceRepository.ListAsync(p => p.ServiceId.Equals(service_id));
            return Ok(queryset);
        }

        // Get all with practitioner ID
        [HttpGet]
        [Route("by_practitioner_id/{practitioner_id}")]
        public async Task<IActionResult> GetListByPractitionerIdAsync(string practitioner_id)
        {

            // Query for all entities with specific practitioner id
            var queryset = await _repo.PractitionerServiceRepository.ListAsync(p => p.PractitionerId.Equals(practitioner_id));
            return Ok(queryset);
        }

        // CRUD endpoints 
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<PractitionerService>> CreatePractitionerService(PractitionerService practitioner)
        {
            // Add the entity
            try
            {
                await _repo.PractitionerServiceRepository.CreateAsync(practitioner);

                return Ok(practitioner);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<PractitionerService>> UpdatePractitionerService(PractitionerService practitioner)
        {
            var originalPractitioner = await _repo.PractitionerServiceRepository.UpdateAsync(practitioner);

            return Ok(originalPractitioner);
        }

        [HttpPost]
        [Route("delete")]
        public ActionResult<PractitionerService> DeletePractitionerService(PractitionerService practitioner)
        {

            try
            {
                _repo.PractitionerServiceRepository.Delete(practitioner);
                return Ok("Entity Deleted");
            }
            catch
            {
                return BadRequest("Entity does not exist");
            }
        }
    }
}

