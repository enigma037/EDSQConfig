using EDSQConfig.Application.ConfigurationDefinitions.Commands;
using EDSQConfig.Application.ConfigurationDefinitions.Queries;
using EDSQConfig.Application.Organizations.Queries;
using EDSQConfig.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDSQConfig.API.Controllers
{

    public class ConfigurationDefinitionsController : BaseController
    {
        [Produces("application/json")]
        [ProducesResponseType(typeof(Unit), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateConfigurationDefinitonCommand command)
        {
            try
            {
                var response = await Mediator.Send(command);
                return Ok(response);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<ListConfigurationDefinitonResponse>), 200)]
        [HttpGet]
        public async Task<IActionResult> List([FromQuery] ListConfigurationDefinitionQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);

        }

        [Produces("application/json")]
        [ProducesResponseType(typeof(GetConfigurationDefinitionByIdResponse), 200)]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetConfigurationDefinitionByIdQuery query)
        {
            try
            {
                var response = await Mediator.Send(query);
                return Ok(response);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Produces("application/json")]
        [ProducesResponseType(typeof(Unit), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateConfigurationDefinitionCommand command)
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
