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
        public async Task<IActionResult> Index()
        {
            var applicationConfiguration = new List<ApplicationConfiguration>();
            return View(applicationConfiguration);
        }

        [HttpGet]
        public async Task<IActionResult> AddOrEdit(int id, CancellationToken cancellationToken)
        {
            ViewBag.OrganizationSelectOptions = await _service.GetOrganizationsSelectItemsAsync(cancellationToken);
            if (id == 0)
            {
                return View(new ApplicationConfiguration());
            }
            else
            {
                var applicationConfiguration = new ApplicationConfiguration();

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
        public IActionResult AddOrEdit(int id, [Bind("ID,ApplicationCode,OrganizationID,ConfigurationDefinitionID,ConfigurationValue,DisabledDateTime")] ApplicationConfiguration applicationConfiguration)
        {
            if (ModelState.IsValid)
            {
                //if (id == 0)
                //{
                //    var command = new CreateApplicationConfigurationCommand { ApplicationConfiguration = applicationConfiguration };
                //    _mediator.Send(command);
                //}
                //else
                //{
                //    var command = new UpdateApplicationConfigurationCommand { applicationConfiguration = applicationConfiguration };
                //    _mediator.Send(command);
                //}
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
