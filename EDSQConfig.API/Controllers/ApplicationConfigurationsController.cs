using EDSQConfig.Application.ApplicationConfigurations.Commands;
using EDSQConfig.Application.ApplicationConfigurations.Queries;
using EDSQConfig.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDSQConfig.API.Controllers
{
    public class ApplicationConfigurationsController : BaseController
    {
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<ListAppConfigsResponse>), 200)]
        [HttpGet]
        public async Task<IActionResult> List([FromQuery] ListAppConfigsQuery query)
        {
            var response = await Mediator.Send(query);

            return Ok(response);
        }

        [Produces("application/json")]
        [ProducesResponseType(typeof(Unit), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAppConfigCommand command)
        {
            try
            {
                command.Id = id;
                var response = await Mediator.Send(command);
                return Ok(response);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
