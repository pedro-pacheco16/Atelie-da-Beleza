using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PaulaPachecoHairStyle.Models;
using PaulaPachecoHairStyle.Models.ViewModel;
using PaulaPachecoHairStyle.Repositories.Interfaces;

namespace PaulaPachecoHairStyle.Controllers
{
    [Route("Appointment")]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentController(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public ActionResult Index()
        {
            var appointments = _appointmentRepository.GetAll();
            return View(appointments);
        }

        [HttpGet("Create")]
        public ActionResult Create()
        {
            var viewModel = new AppointmentFormViewModel
            {
                AvailableProcedures = _appointmentRepository
                    .GetAllProcedures()
                    .Select(p => new SelectListItem
                    {
                        Value = p.ProcedureId.ToString(),
                        Text = p.Name
                    })
            };

            return View(viewModel);
        }

        [HttpPost("Create")]
        public ActionResult Create(AppointmentFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Prepara mensagens de erro para exibir no popup
                var errorMessages = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return Json(new
                {
                    success = false,
                    message = string.Join("<br>", errorMessages)
                });
            }

            if (!_appointmentRepository.IsTimeAvailable(model.AppointmentDate))
            {
                return Json(new
                {
                    success = false,
                    message = "Este horário já está ocupado."
                });
            }

            // Cria o agendamento
            var appointment = new Appointment
            {
                CustomerName = model.CustomerName,
                ProcedureId = model.ProcedureId,
                AppointmentDate = model.AppointmentDate,
                Email = model.Email,
                Phone = model.Phone
            };

            _appointmentRepository.Add(appointment);

            return Json(new
            {
                success = true,
                message = "✅ Agendamento confirmado com sucesso!"
            });
        }

        [HttpGet("IsTimeAvailable")]
        public JsonResult IsTimeAvailable(DateTime date)
        {
            var available = _appointmentRepository.IsTimeAvailable(date);
            return Json(available);
        }

    }
}
