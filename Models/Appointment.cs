using System.ComponentModel.DataAnnotations;

namespace PaulaPachecoHairStyle.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public int ProcedureId { get; set; }

        public Procedure Procedure { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
