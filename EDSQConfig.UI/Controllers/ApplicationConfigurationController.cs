#nullable disable
using EDSQConfig.UI.Interfaces;
using EDSQConfig.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EDSQConfig.UI.Controllers
{
    public class ApplicationConfigurationController : Controller
    {
        private readonly IApplicationConfigurationService _service;
        public ApplicationConfigurationController(IApplicationConfigurationService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var applicationConfiguration = await _service.ListAsync(cancellationToken);
            return View(applicationConfiguration);
        }

        [HttpGet]
        public async Task<IActionResult> AddOrEdit(CancellationToken cancellationToken, int id = 0)
        {
            ViewBag.OrganizationSelectOptions = await _service.GetOrganizationsSelectItemsAsync(cancellationToken);
            ViewBag.ConfigurationDefinitationSelectOption = await _service.GetConfigurationDefinitationSelectItemsAsync(cancellationToken);
            if (id == 0)
            {
                return View(new ApplicationConfiguration());
            }
            else
            {
                var applicationConfiguration = await _service.GetByIdAsync(id, cancellationToken);

                //await _mediator.Send(new GetApplicationConfigurationDetailRequest { Id = id });
                if (applicationConfiguration == null)
                {
                    return NotFound();
                }
                return View(applicationConfiguration);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("ID,ApplicationCode,OrganizationID,ConfigurationDefinitionID,ConfigurationValue,DisabledDateTime")] ApplicationConfiguration applicationConfiguration, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    var command = await _service.CreateAsync(applicationConfiguration, cancellationToken);
                }
                else
                {
                    var command = await _service.UpdateAsync(id, applicationConfiguration, cancellationToken);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(applicationConfiguration);
        }

        public IActionResult Delete(int id)
        {
            // var command = new DeleteApplicationConfigurationCommand { Id = id };
            // _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }


    }
}
