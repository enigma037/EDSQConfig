using EDSQConfig.Application.Organizations.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDSQConfig.API.Controllers
{

    public class OrganizationsController : BaseController
    {

        [Produces("application/json")]
        [ProducesResponseType(typeof(List<ListOrganizationsResponse>), 200)]
        [HttpGet]
        public async Task<IActionResult> List([FromQuery] ListOrganizationsQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);

        }

        [Produces("application/json")]
        [ProducesResponseType(typeof(ListConfigDefSelectOptionsResponse), 200)]
        [HttpGet("select-options")]
        public async Task<IActionResult> SelectOptions()
        {
            var query = new ListConfigDefSelectOptionsQuery();
            var response = await Mediator.Send(query);
            return Ok(response);
        }
    }
}
