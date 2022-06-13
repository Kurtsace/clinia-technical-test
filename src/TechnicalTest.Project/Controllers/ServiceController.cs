using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Project.Domain;
using TechnicalTest.Project.Infrastructure;
using TechnicalTest.Project.Infrastructure.Repositories;
using TechnicalTest.Project.Pagination;

namespace TechnicalTest.Project.Controllers
{
    // API endpoint for return Service entities 
    [ApiController]
    [Route("[controller]")]
    public class ServiceController : ControllerBase
    {
        private RepositoryWrapper _repo;
        public ServiceController(TestDbContext context)
        {
            _repo = new RepositoryWrapper(context);
        }

        // Get all items
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetListAsync()
        {

            // Query for all entities paginated and return
            var queryset = await _repo.ServiceRepository.ListAsync(s => s.Id == s.Id);
            return Ok(queryset);
        }

        // Get all items in a paginated list
        // all/paginated?page=1&pagesize=10
        [HttpGet]
        [Route("all/paginated")]
        public async Task<IActionResult> GetListPaginatedAsync([FromQuery] PaginationModel @params)
        {

            // Query for all entities paginated and return
            var queryset = await _repo.ServiceRepository.GetEntityListPaginatedAsync(s => s.Id == s.Id, @params);
            return Ok(queryset); 
        }

        // Get all with ID
        [HttpGet]
        [Route("by_id/{id}")]
        public async Task<IActionResult> GetListByIDAsync(string id)
        {

            // Query for all entities with specific id
            var queryset = await _repo.ServiceRepository.ListAsync(s => s.Id.Equals(id));
            return Ok(queryset);
        }

        // Get all with name
        [HttpGet]
        [Route("by_name/{name}")]
        public async Task<IActionResult> GetListByNameAsync(string name)
        {

            // Query for all entities with specific name
            var queryset = await _repo.ServiceRepository.ListAsync((s => s.Name.Equals(name)));
            return Ok(queryset);
        }

        // CRUD endpoints 
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Service>> CreateService(Service service)
        {
            // Add the entity
            try
            {
                await _repo.ServiceRepository.CreateAsync(service);

                return Ok(service);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<Service>> UpdateService(Service service)
        {
            var originalService = await _repo.ServiceRepository.UpdateAsync(service);
            
            return Ok(originalService);
        }

        [HttpPost]
        [Route("delete")]
        public ActionResult<Service> DeleteService(Service service)
        {

            try
            {
                _repo.ServiceRepository.Delete(service);
                return Ok("Entity Deleted");
            }
            catch
            {
                return BadRequest("Entity does not exist");
            }
        }
    }
}