using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PaulaPachecoHairStyle.Models.ViewModel
{
    public class AppointmentFormViewModel
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [Display(Name = "Nome")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Serviço é obrigatório")]
        [Display(Name = "Serviço")]
        public int ProcedureId { get; set; }

        [Required(ErrorMessage = "Data e hora são obrigatórias")]
        [Display(Name = "Data e Hora")]
        public DateTime AppointmentDate { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório")]
        [Phone(ErrorMessage = "Telefone inválido")]
        [Display(Name = "Telefone")]
        public string Phone { get; set; }

        public IEnumerable<SelectListItem> AvailableProcedures { get; set; }
    }
}

