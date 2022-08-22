using EDSQConfig.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EDSQConfig.UI.Controllers
{
    public class SSISConfigController : Controller
    {
        public SSISConfigController()
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ssisConfig = new List<SSIS_Config>();
            return View(ssisConfig);
        }

        [HttpGet]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new SSIS_Config());
            }
            else
            {
                var ssisConfig = new SSIS_Config();
                if (ssisConfig == null)
                {
                    return NotFound();
                }
                return View(ssisConfig);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, SSIS_Config ssisConfig)
        {
            if (ModelState.IsValid)
            {
                //if (id == 0)
                //{
                //    var command = new CreateSSISConfigCommand { ssisConfig = ssisConfig };
                //    _mediator.Send(command);
                //}
                //else
                //{
                //    var command = new UpdateSSISConfigCommand { ssisConfig = ssisConfig };
                //    _mediator.Send(command);
                //}
                return RedirectToAction(nameof(Index));
            }
            return View(ssisConfig);
        }

        public IActionResult Delete(int id)
        {
            //var command = new DeleteSSISConfigCommand { Id = id };
            //_mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
