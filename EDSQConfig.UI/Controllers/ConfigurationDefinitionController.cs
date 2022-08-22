#nullable disable
using EDSQConfig.UI.Interfaces;
using EDSQConfig.UI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EDSQConfig.UI.Controllers
{
    public class ConfigurationDefinitionController : Controller
    {
        private readonly IConfigurationDefinitionService _service;

        public ConfigurationDefinitionController(IConfigurationDefinitionService service)
        {
            _service=service;
        }

        // GET: ConfigurationDefinition
        [HttpGet]
        public async Task<IActionResult>Index(CancellationToken cancellationToken)
        {
            var configurationDefinitions = await _service.ListAsync(cancellationToken);
            return View(configurationDefinitions);
        }

        [HttpGet]
        public async Task<IActionResult> AddOrEdit(CancellationToken cancellationToken, int id = 0)
        {
            if (id == 0)
            {
                return View(new ConfigurationDefinition());
            }
            else
            {
                var configurationDefinition = await _service.GetByIdAsync(id, cancellationToken);//await _mediator.Send(new GetConfigurationDefinitionDetailRequest { Id = id });
                if (configurationDefinition == null)
                {
                    return NotFound();
                }
                return View(configurationDefinition);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, [Bind("ID,ConfigurationType,ConfigurationDescription,DefaultValue,CreateUserID,CreateDateTime,LastUpdateUserID,LastUpdateDateTime")] ConfigurationDefinition configurationDefinition, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    var command = _service.CreateAsync(configurationDefinition, cancellationToken);
                }
                else
                {
                    var command = _service.UpdateAsync(id, configurationDefinition, cancellationToken);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(configurationDefinition);
        }

        public IActionResult Delete(int id)
        {
           // var command = new DeleteConfigurationDefinitionCommand { Id = id };
         //   _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

    }
}
