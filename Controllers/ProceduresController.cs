using Microsoft.AspNetCore.Mvc;
using PaulaPachecoHairStyle.Repositories.Interfaces;

namespace PaulaPachecoHairStyle.Controllers
{
    public class ProceduresController : Controller
    {
        private readonly IProceduresRepository _proceduresRepository;

        public ProceduresController(IProceduresRepository proceduresRepository)
        {
            _proceduresRepository = proceduresRepository;
        }
        public IActionResult List()
        {
            var procedures = _proceduresRepository.Procedures;
            return View(procedures);
        }

    }
}
