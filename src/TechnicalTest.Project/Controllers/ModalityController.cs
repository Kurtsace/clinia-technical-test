using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTest.Project.Domain.Modalities;
using TechnicalTest.Project.Infrastructure.Repositories;
using TechnicalTest.Project.Stores;

namespace TechnicalTest.Project.Controllers
{
    // Endpoint for Modality
    [ApiController]
    [Route("[controller]")]
    public class ModalityController : Controller
    {

        private IEnumerable<Modality> modalities;

        public ModalityController()
        {
            // Read all modalities and deserialize into Modality objs
            GenericStore gs = new GenericStore();

            // TODO
            // Cannot deserialize into abstract class modality.
            // Did some research and it turns out it does not have the ability
            // to dynamically determine the subclass without custom settings/solutions
            // This modalities list will contain all deserialized objs as a Modality class 
            // with type and name 
            //
            // Update:
            // Perhaps a solution is to read eveything in as a Modality base class and reiterate
            // through the list and dynamically convert into the correct type. Do more research and 
            // come back to this
            modalities = gs.ReadAll<Modality>();
        }

        // List all modalities 
        [HttpGet]
        [Route("all")]
        public IActionResult GetListAsync()
        {
            return Ok(modalities);
        }
    }
}
